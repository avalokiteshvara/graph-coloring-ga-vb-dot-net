Imports System
Imports System.Collections.Generic
Imports System.IO

Public Class GraphLoader
    Private Sub New()
    End Sub

    Public Shared NODES As Integer
    Public Shared EDGES As Integer

    Public Shared Function LoadGraph(ByVal path As String) As List(Of List(Of Integer))
        Dim result As New List(Of List(Of Integer))()
        Try
            Dim br As New StreamReader(path)
            Dim line As String = ""
            Dim tokens() As String

            line = br.ReadLine()
            Do While line IsNot Nothing
                If line.StartsWith("p") Then
                    tokens = StringHelperClass.StringSplit(line, " ", True)
                    NODES = Convert.ToInt32(tokens(2))
                    EDGES = Convert.ToInt32(tokens(3))

                    For i As Integer = 0 To NODES - 1
                        result.Add(New List(Of Integer)())
                    Next i
                ElseIf line.StartsWith("e") Then
                    tokens = StringHelperClass.StringSplit(line, " ", True)
                    Dim node As Integer = Convert.ToInt32(tokens(1)) - 1
                    Dim edge As Integer = Convert.ToInt32(tokens(2)) - 1
                    result(node).Add(edge)
                End If
                line = br.ReadLine()
            Loop
        Catch e As FileNotFoundException
            Console.WriteLine(e.ToString())
            Console.Write(e.StackTrace)
        Catch e As IOException
            Console.WriteLine(e.ToString())
            Console.Write(e.StackTrace)
        End Try
        Return result
    End Function
End Class
