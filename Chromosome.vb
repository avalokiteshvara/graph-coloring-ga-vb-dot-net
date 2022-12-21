Imports System.Collections.Generic

Public NotInheritable Class Chromosome
    Private _genes() As Integer
    Private _fitness As Double
    Private _colors As Integer

    Public Sub New(ByVal genes() As Integer, ByVal colors As Integer)
        Me._genes = genes
        Me._colors = colors
    End Sub

    Public Sub New(ByVal length As Integer, ByVal colors As Integer)
        Fitness = 0
        _genes = New Integer(length - 1) {}
        Me._colors = colors
    End Sub

    Public Sub New(ByVal old As Chromosome)
        Me.Fitness = old.Fitness
        Me._colors = old._colors

        _genes = New Integer(old._genes.Length - 1) {}
        For i As Integer = 0 To old._genes.Length - 1
            _genes(i) = old._genes(i)
        Next

    End Sub

    Public Property Colors As Integer
        Get
            Return _colors
        End Get
        Set(ByVal colors As Integer)
            Me._colors = colors
        End Set
    End Property

    Public Property Genes As Integer()
        Get
            Return _genes
        End Get
        Set(ByVal genes() As Integer)
            Me._genes = genes
        End Set
    End Property


    Public Property Fitness As Double
        Get
            Return _fitness
        End Get
        Set(ByVal fitness As Double)
            Me._fitness = fitness
        End Set
    End Property


    Public Sub GenerateGenes()
        Dim sr As New Random()
        For j As Integer = 0 To _genes.Length - 1
            _genes(j) = sr.Next(_colors)
        Next j

    End Sub

    Public Function CountColors() As Integer
        Dim col(_colors - 1) As Integer

        For i As Integer = 0 To _genes.Length - 1
            col(_genes(i)) += 1
        Next i

        Dim counter As Integer = 0

        For Each c As Integer In col
            counter = If(c = 0, counter, counter + 1)
        Next c
        _colors = counter
        Return _colors
    End Function

    Public Sub Evaluate(ByVal graph As List(Of List(Of Integer)))
        Dim conflicts As Integer = 0
        For i As Integer = 0 To _genes.Length - 1
            Dim current As Integer = _genes(i)
            Dim edgesArr As List(Of Integer) = graph(i)
            For j As Integer = 0 To edgesArr.Count - 1
                If _genes(edgesArr(j)) = current Then
                    conflicts += 1
                End If
            Next j
        Next i
        Fitness = conflicts
    End Sub

    Public Sub MinimizeErrors(ByVal graph As List(Of List(Of Integer)), ByVal mutation As Double)
        For i As Integer = 0 To _genes.Length - 1
            Dim sr As New Random()
            If sr.NextDouble() <= mutation Then
                Dim quantities(_colors - 1) As Integer

                Dim eg As List(Of Integer) = graph(i)
                For j As Integer = 0 To eg.Count - 1
                    quantities(_genes(eg(j))) += 1
                Next j

                Dim conflicts As Integer = quantities(_genes(i))
                If conflicts <> 0 Then
                    _genes(i) = sr.Next(_colors)
                End If
            End If
        Next i
    End Sub
End Class
