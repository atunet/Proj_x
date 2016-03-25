﻿/*
Copyright (c) 2015-2016 topameng(topameng@qq.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaInterface
{
    public class ObjectTranslator
    {        
        private class DelayGC
        {
            public DelayGC(int id, float time)
            {
                this.id = id;
                this.time = time;
            }

            public int id;
            public float time;
        }

        private class CompareObject : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return object.ReferenceEquals(x, y);                
            }

            public int GetHashCode(object obj)
            {
                if (obj != null)
                {
                    return obj.GetHashCode();
                }

                return 0;
            }
        }

        public bool LogGC { get; set; }
        public readonly Dictionary<object, int> objectsBackMap = new Dictionary<object, int>(new CompareObject());
        public readonly LuaObjectPool objects = new LuaObjectPool();
        private List<DelayGC> gcList = new List<DelayGC>();

        private static ObjectTranslator _translator = null;

        public ObjectTranslator()
        {
            LogGC = false;

#if !MULTI_STATE
            _translator = this;
#endif
        }

        public int AddObject(object obj)
        {
            int index = objects.Add(obj);

            if (!TypeChecker.IsValueType(obj.GetType()))
            {
                objectsBackMap[obj] = index;
            }

            return index;
        }

        public static ObjectTranslator Get(IntPtr L)
        {
#if !MULTI_STATE
                return _translator;
#else
                return LuaState.GetTranslator(L);
#endif
        }

        //完全移除一个对象，适合lua gc
        public void RemoveObject(int udata)
        {
            RemoveFromGCList(udata);
            object o = objects.Remove(udata);

            if (o != null)
            {
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                if (LogGC)
                {
                    Debugger.Log("remove object {0}, id {1}", o, udata);
                }
            }
        }

        public object GetObject(int udata)
        {
            return objects.TryGetValue(udata);         
        }

        //删除，但不移除一个lua对象
        public void Destroy(int udata)
        {
            RemoveFromGCList(udata);
            object o = objects.Destroy(udata);

            if (o != null)
            {
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                if (LogGC)
                {
                    Debugger.Log("destroy object {0}, id {1}", o, udata);
                }
            }
        }

        public void DelayDestroy(int id, float time)
        {
            gcList.Add(new DelayGC(id, time));
        }

        public bool Getudata(object o, out int index)
        {
            index = -1;
            return objectsBackMap.TryGetValue(o, out index);
        }

        public void SetBack(int index, object o)
        {
            object obj = objects.Replace(index, o);
            objectsBackMap.Remove(obj);
            objectsBackMap[o] = index;
        }

        void RemoveFromGCList(int id)
        {
            int index = gcList.FindIndex((p) => { return p.id == id; });

            if (index >= 0)
            {
                gcList.RemoveAt(index);                                
            }
        }
        
        void DestroyUnityObject(int udata)
        {
            object o = objects.Destroy(udata);

            if (o != null)
            {                
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                UnityEngine.Object obj = o as UnityEngine.Object;

                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj);
                }

                if (LogGC)
                {
                    Debugger.Log("destroy object {0}, id {1}", o, udata);
                }
            }
        }

        public void Collect()
        {
            if (gcList.Count == 0)
            {
                return;
            }

            float delta = Time.deltaTime;

            for (int i = gcList.Count - 1; i >= 0; i--)
            {
                float time = gcList[i].time - delta;

                if (time <= 0)
                {
                    DestroyUnityObject(gcList[i].id);                    
                    gcList.RemoveAt(i);
                }
                else
                {
                    gcList[i].time = time;
                }
            }
        }

        public void Dispose()
        {
            objectsBackMap.Clear();
            objects.Clear();     
            
#if !MULTI_STATE
            _translator = null;
#endif
        }
    }
}