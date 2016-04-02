require("basetype_pb")
local BaseTypePb = _G['Protol/basetype_pb']

require("errorcode_pb")
local ErrorCodePb = _G['Protol/errorcode_pb']


module(..., package.seeall)


function ParseError()
	local revCmd = ErrorCodePb.MessageErrorCode()
	revCmd:ParseFromString(CSInterface.s_recvBytes)
	print("recv errorcode: 0x" .. string.format("%x", revCmd.code))

	if ErrorCodePb.USER_RE_LOGIN == revCmd.code then
	else
	end
end