Imports System.IO
Imports System.Text
Public Class clsFile
    Public Sub SaveTxt(ByVal strPath As String, ByVal lsData As List(Of String))
        File.AppendAllLines(strPath, lsData, Encoding.Default)
    End Sub
    Public Function ReadTxt(ByVal strPath As String) As String()
        Dim arr0() As String = File.ReadAllLines(strPath)
        Return arr0
    End Function
End Class
