Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmMain

    Private g As System.Drawing.Graphics
    Dim _brush() As Brush = {
                                Brushes.Red,
                                Brushes.Yellow,
                                Brushes.Green,
                                Brushes.Blue,
                                Brushes.Black,
                                Brushes.Cyan,
                                Brushes.DarkGray,
                                Brushes.Gray,
                                Brushes.LightGray,
                                Brushes.Magenta,
                                Brushes.Pink,
                                Brushes.White
                            }

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        'Integer.TryParse(Me.txtPopulationSize.Text, _populationSize)
        'Double.TryParse(Me.txtCrossProbability.Text, _crossProb)
        'Double.TryParse(Me.txtMutationProbability.Text, _mutProb)
        'Integer.TryParse(Me.txtMaxIteration.Text, _maxIterations)
        txtLogs.Clear()
        'start
        Dim graph As List(Of List(Of Integer)) = GraphLoader.LoadGraph("kasus_graph.col")
        Dim allTimeWinners() As Chromosome

        If graph IsNot Nothing Then
            Dim nodes As Integer = GraphLoader.NODES
            Dim edges As Integer = GraphLoader.EDGES


            Dim population As Integer
            Integer.TryParse(Me.txtPopulationSize.Text, population)

            'hanya untuk kasus ini aja
            Dim colors As Integer = 3
           
            Dim maxIteration As Integer
            Integer.TryParse(Me.txtMaxIteration.Text, maxIteration)

            Dim mutProb As Double
            Double.TryParse(Me.txtMutationProbability.Text, mutProb)
           
            Dim crosProb As Double
            Double.TryParse(Me.txtCrossProbability.Text, crosProb)

            allTimeWinners = New Chromosome(colors - 1) {}
            Dim isFound As Boolean = True

            'genetic
            Dim i As Integer = colors - 1
            Do While i > 1 AndAlso isFound
                'Me.txtLogs.AppendText("----------------------------------------" & (i + 1) & vbCrLf)
                Dim ev As New Evolution(graph, nodes, edges, population, maxIteration, mutProb, crosProb, i + 1)
                allTimeWinners(i) = ev.Evolve()
                Me.txtLogs.AppendText(ev.Logs)
                'start render
                RenderA(Me._brush(allTimeWinners(i).Genes(0)))
                RenderB(Me._brush(allTimeWinners(i).Genes(1)))
                RenderC(Me._brush(allTimeWinners(i).Genes(2)))
                RenderD(Me._brush(allTimeWinners(i).Genes(3)))
                RenderE(Me._brush(allTimeWinners(i).Genes(4)))
                RenderF(Me._brush(allTimeWinners(i).Genes(5)))
                'end render
                If allTimeWinners(i).Fitness > 0 Then
                    isFound = False
                End If
                i -= 1
            Loop

        End If
        Me.txtLogs.AppendText("Done")
    End Sub


    Private Sub RenderA(ByVal br As Brush)
        Dim point(2) As System.Drawing.Point
        point(0) = New Point(0, 0)
        point(1) = New Point(0, 100)
        point(2) = New Point(100, 0)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub

    Private Sub RenderB(ByVal br As Brush)
        Dim point(2) As System.Drawing.Point
        point(0) = New Point(0, 100)
        point(1) = New Point(100, 100)
        point(2) = New Point(100, 0)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub

    Private Sub RenderC(ByVal br As Brush)
        Dim point(4) As System.Drawing.Point
        point(0) = New Point(100, 0)
        point(1) = New Point(100, 50)
        point(2) = New Point(200, 50)
        point(3) = New Point(200, 0)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub

    Private Sub RenderD(ByVal br As Brush)
        Dim point(3) As System.Drawing.Point
        point(0) = New Point(100, 50)
        point(1) = New Point(100, 100)
        point(2) = New Point(200, 100)
        point(3) = New Point(200, 50)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub
    Private Sub RenderE(ByVal br As Brush)
        Dim point(2) As System.Drawing.Point
        point(0) = New Point(200, 0)
        point(1) = New Point(300, 100)
        point(2) = New Point(200, 100)
        'point(4) = New Point(200, 50)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub

    Private Sub RenderF(ByVal br As Brush)
        Dim point(2) As System.Drawing.Point
        point(0) = New Point(300, 100)
        point(1) = New Point(300, 0)
        point(2) = New Point(200, 0)
        'point(4) = New Point(200, 50)

        g = picBox.CreateGraphics
        g.FillPolygon(br, point)
        g.DrawPolygon(New Pen(Color.Black, 2), point)
    End Sub
    Private Sub FrmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class