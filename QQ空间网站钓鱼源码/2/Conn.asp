
<%
Dim Conn
Const DbFileName = "..\TB_Data\t#2b&^%$$the!@#way.cgi"

Sub ConnOpen()
    'On Error Resume Next
	Dim ConnStr
	ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath(DbFileName)
    Set Conn = Server.CreateObject("Adodb.Connection")
	Conn.Open ConnStr
	If Err Then
        Err.Clear()
		Set Conn = Nothing
		Response.Write "打开数据库失败,请检查Conn.asp中的设置!"
		Response.End
	End If 
End Sub
Sub ConnClose()
    On Error Resume Next
	If IsObject(Conn) Then
        Conn.Close
		Set Conn = Nothing
	End If 
End Sub
Function RegStr(Pattern,Str,ErrMsg)
    Dim RegEx
	Set RegEx = new RegExp
    RegEx.Pattern = Pattern
    If Not RegEx.Test(Str) Then
		Response.Write "<script>alert('" & ErrMsg & "');history.go(-1);</script>"
		Response.End
	End If 
		Set Reg = Nothing
	End Function



Call ConnOpen()

%>