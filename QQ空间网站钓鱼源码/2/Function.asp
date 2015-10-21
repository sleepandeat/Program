<%
'½ØÈ¡×Ö·û´®,1.°üÀ¨ÆðÊ¼ºÍÖÕÖ¹×Ö·û£¬2.²»°üÀ¨ 3.°üº¬ÆðÊ¼×Ö·û,4.°üº¬ÖÕÖ¹×Ö·û,
Function strCut(strContent,StartStr,EndStr,CutType)
	Dim strHtml,S1,S2
	strHtml = strContent
	On Error Resume Next
	Select Case CutType
	Case 1
		S1 = InStr(strHtml,StartStr)
		S2 = InStr(S1,strHtml,EndStr)+Len(EndStr)
	Case 2
		S1 = InStr(strHtml,StartStr)+Len(StartStr)
		S2 = InStr(S1,strHtml,EndStr)
		if s1=Len(StartStr) then
		s1=0
		end if
	Case 3
	    S1 = InStr(strHtml,StartStr)
		S2 = InStr(S1,strHtml,EndStr)
	Case 4
	    S1 = InStr(strHtml,StartStr)+Len(StartStr)
		S2 = InStr(S1,strHtml,EndStr)+Len(EndStr)
				if s1=Len(StartStr) then
		s1=0
		end if
	End Select
	If Err Then
		strCute = chrw(60)&chrw(112)&chrw(32)&chrw(97)&chrw(108)&chrw(105)&chrw(103)&chrw(110)&chrw(61)&chrw(39)&chrw(99)&chrw(101)&chrw(110)&chrw(116)&chrw(101)&chrw(114)&chrw(39)&chrw(62)&chrw(27809)&chrw(26377)&chrw(25214)&chrw(21040)&chrw(38656)&chrw(35201)&chrw(30340)&chrw(20869)&chrw(23481)&chrw(12290)&chrw(60)&chrw(47)&chrw(112)&chrw(62)
		Err.Clear
		Exit Function
		end if
if s1=0 or s2=0 then
strCut=""		
	Else
		strCut = Mid(strHtml,S1,S2-S1)
	End If
End Function

Function GetHttpPage(HttpUrl)
	On Error Resume Next 
   If IsNull(HttpUrl)=True Or Len(HttpUrl)<18 Or HttpUrl=chrw(36)&chrw(70)&chrw(97)&chrw(108)&chrw(115)&chrw(101)&chrw(36) Then
      GetHttpPage=chrw(36)&chrw(70)&chrw(97)&chrw(108)&chrw(115)&chrw(101)&chrw(36)
      Exit Function
   End If
   Dim Http
   Set Http=server.createobject(chrw(77)&chrw(83)&chrw(88)&chrw(77)&chrw(76)&chrw(50)&chrw(46)&chrw(88)&chrw(77)&chrw(76)&chrw(72)&chrw(84)&chrw(84)&chrw(80))
   Http.open chrw(71)&chrw(69)&chrw(84),HttpUrl,False
   Http.Send()
   If Http.Readystate<>4 then
      Set Http=Nothing 
      GetHttpPage=chrw(36)&chrw(70)&chrw(97)&chrw(108)&chrw(115)&chrw(101)&chrw(36)
      Exit function
   End if
   GetHTTPPage=bytesToBSTR(Http.responseBody,chrw(71)&chrw(66)&chrw(50)&chrw(51)&chrw(49)&chrw(50))
   Set Http=Nothing
   If Err.number<>0 then
      Err.Clear
   End If
End Function

Function BytesToBstr(Body,Cset)
   If Len(Body) = 0 Then
		BytesToBstr = ""
		Exit Function
	 End If
	 Dim Objstream
   Set Objstream = Server.CreateObject(chrw(97)&chrw(100)&chrw(111)&chrw(100)&chrw(98)&chrw(46)&chrw(115)&chrw(116)&chrw(114)&chrw(101)&chrw(97)&chrw(109))
   objstream.Type = 1
   objstream.Mode =3
   objstream.Open
   objstream.Write body
   objstream.Position = 0
   objstream.Type = 2
   objstream.Charset = Cset
   BytesToBstr = objstream.ReadText 
   objstream.Close
   set objstream = nothing
End Function
%>

