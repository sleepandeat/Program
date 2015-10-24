Module Module1

    Sub Main()
        Command1_Click()
    End Sub
    Private Sub Command1_Click()
        Dim HEXSTR As String
        Dim A() As Byte
        HEXSTR = Text1
        ReDim A(Len(HEXSTR) / 2)
        For I = 0 To Len(HEXSTR) Step 2
            A(I / 2) = Val("&H" & Mid(HEXSTR, I + 1, 2))
        Next
        Open "c:\123.PNG" For Binary As #1
Put #1, , A()
Close #1
End Sub

End Module
