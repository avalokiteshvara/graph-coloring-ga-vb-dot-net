Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Public NotInheritable Class Evolution

    Private _population() As Chromosome
    Private ReadOnly _graph As List(Of List(Of Integer))
    Private ReadOnly _randomGenerator As Random
    Private ReadOnly _nodes As Integer
    Private ReadOnly _edges As Integer
    Private ReadOnly _colors As Integer
    Private ReadOnly _maxIterations As Integer
    Private ReadOnly _mutProb As Double
    Private ReadOnly _crossProb As Double
    Private _logs As String
    'Private Const ConstMutation As Double = 0.7
    'Private Const ConstCrossover As Double = 0.8


    Public Sub New(ByVal graph As List(Of List(Of Integer)),
                   ByVal nodes As Integer,
                   ByVal edges As Integer,
                   ByVal population As Integer,
                   ByVal maxIterations As Integer,
                   ByVal mutProb As Double,
                   ByVal crossProb As Double,
                   ByVal colors As Integer)

        Me._graph = graph
        Me._nodes = nodes
        Me._edges = edges
        Me._population = New Chromosome(population - 1) {}
        Me._maxIterations = maxIterations
        Me._mutProb = mutProb
        Me._crossProb = crossProb
        Me._colors = colors
        GenerateFirstPopulation()
        EvaluatePopulation()
        _randomGenerator = New Random()
    End Sub

    Public Property Logs As String
        Get
            Return _logs
        End Get
        Set(ByVal value As String)
            _logs = value & vbCrLf
        End Set
    End Property

    Private Sub EvaluatePopulation()
        For i As Integer = 0 To Me._population.Length - 1
            Me._population(i).Evaluate(_graph)
        Next i
    End Sub

    Private Sub GenerateFirstPopulation()
        For i As Integer = 0 To _population.Length - 1
            _population(i) = New Chromosome(_nodes, _colors)
            _population(i).GenerateGenes()
        Next i
    End Sub

    Public Function Evolve() As Chromosome

        Dim iterationsLeft = _maxIterations
        EvaluatePopulation()
        Dim fittest As Chromosome
        Dim worst As Chromosome
        fittest = New Chromosome(FindFittest())
        worst = New Chromosome(FindWorst())

        While Math.Abs(fittest.Fitness - 0) > 0.0 AndAlso iterationsLeft > 0

            SelectPopulation()
            CrossoverPopulation()
            MutatePopulation()
            EvaluatePopulation()
            fittest = New Chromosome(FindFittest())
            worst = New Chromosome(FindWorst())
            If (iterationsLeft Mod 100 = 0) Then
                'Console.WriteLine(String.Format("Remaining iteration {0}; Best {1}; Worst {2}; avg {3};", iterationsLeft, fittest.Fitness, worst.Fitness, FindAvg()))
                Me._logs &= String.Format("Remaining iteration {0}; Best {1}; Worst {2}; avg {3};", iterationsLeft, fittest.Fitness, worst.Fitness, FindAvg()) & vbCrLf
            End If

            iterationsLeft -= 1
        End While

        If (Math.Abs(fittest.Fitness - 0.0) <= 0.0) Then

            Dim color() As String = {"MERAH",
                                     "KUNING",
                                     "HIJAU",
                                     "BIRU",
                                     "HITAM",
                                     "CYAN",
                                     "DARK_GRAY",
                                     "GRAY",
                                     "LIGHTGRAY",
                                     "MAGENTA",
                                     "PINK",
                                     "PUTIH"}

            'Console.WriteLine("Solution Found")
            'Console.WriteLine("Remaining iteration: " & (iterationsLeft))
            'Console.WriteLine(vbTab & "Best, " & fittest.Fitness)
            'Console.WriteLine(vbTab & "Worst, " & worst.Fitness)
            'Console.WriteLine(vbTab & "avg, " & FindAvg())
            'Console.WriteLine("Colors Count: " & fittest.CountColors())
            'For i As Integer = 0 To fittest.Genes.Length - 1
            '    Console.WriteLine(String.Format("Color nodes {0} : {1}", i + 1, color(fittest.Genes(i))))
            'Next
            Me._logs &= "Solution Found" & vbCrLf
            Me._logs &= String.Format("Remaining iteration: {0}", iterationsLeft) & vbCrLf
            Me._logs &= vbTab & String.Format("Best:{0}", fittest.Fitness) & vbCrLf
            Me._logs &= vbTab & String.Format("Worst:{0}", worst.Fitness) & vbCrLf
            Me._logs &= vbTab & String.Format("Avg:{0}", FindAvg()) & vbCrLf
            Me._logs &= vbTab & String.Format("Colors Count:{0}", fittest.CountColors()) & vbCrLf
            For i As Integer = 0 To fittest.Genes.Length - 1
                'Console.WriteLine(String.Format("Color nodes {0} : {1}", i + 1, color(fittest.Genes(i))))
                Me._logs &= vbTab & String.Format("Color nodes {0} : {1}", i + 1, color(fittest.Genes(i))) & vbCrLf
            Next


            'Dim formHasil As New FrmResult
            'System.Windows.Forms.Application.Run(formHasil)
            'formHasil.ColorSeq = fittest.Genes
            'formHasil.ShowDialog()
        Else
            'Console.WriteLine("Remaining iteration: " & (iterationsLeft))
            'Console.WriteLine(vbTab & "Best, " & fittest.Fitness)
            'Console.WriteLine(vbTab & "Worst, " & worst.Fitness)
            'Console.WriteLine(vbTab & "avg, " & FindAvg())
            Me._logs &= String.Format("Remaining iteration: {0}", iterationsLeft) & vbCrLf
            Me._logs &= vbTab & String.Format("Best:{0}", fittest.Fitness) & vbCrLf
            Me._logs &= vbTab & String.Format("Worst:{0}", worst.Fitness) & vbCrLf
            Me._logs &= vbTab & String.Format("Avg:{0}", FindAvg()) & vbCrLf
        End If


        Return fittest
    End Function

    Private Sub SelectPopulation()
        'Roulette Wheel Selection....
        'http://en.wikipedia.org/wiki/Fitness_proportionate_selection#Pseudocode
        '/// In the Roulette wheel selection method [Holland, 1992], the first step is to calculate the cumulative fitness of the 
        '/// whole population through the sum of the fitness of all individuals. After that, the probability of selection is 
        '/// calculated for each individual.
        '/// 
        '/// Then, an array is built containing cumulative probabilities of the individuals. So, n random numbers are generated in the range 0 to fitness sum.
        '/// and for each random number an array element which can have higher value is searched for. Therefore, individuals are selected according to their 
        '/// probabilities of selection. 

        Dim range = _population.Length
        Dim selected = New Chromosome(range - 1) {}

        Dim sumOfFitness As Double
        For i As Integer = 0 To range - 1
            sumOfFitness += _population(i).Fitness
        Next

        Dim accumulativePercent As Double = 0.0
        Dim rouleteWheel = New List(Of Double)()
        For Each chromosome As Chromosome In _population
            accumulativePercent += chromosome.Fitness / sumOfFitness
            rouleteWheel.Add(accumulativePercent)
        Next

        For i As Integer = 0 To range - 1
            Dim pointer = _randomGenerator.NextDouble()
            Dim chromosomeIndex As Integer = rouleteWheel.[Select](Function(value, index) New With {Key .Value = value, Key .Index = index}).FirstOrDefault(Function(r) r.Value >= pointer).Index
            Dim selectedChromosome As Chromosome = _population(chromosomeIndex)

            selected(i) = selectedChromosome
        Next

        _population = selected
    End Sub

    Private Sub CrossoverPopulation()

        Dim children(_population.Length - 1) As Chromosome
        For i As Integer = 0 To _population.Length - 1
            Dim op As Integer
            Do
                op = _randomGenerator.Next(_population.Length)
            Loop While op = i

            If _randomGenerator.NextDouble() <= _crossProb Then
                children(i) = New Chromosome(Crossover(_population(i).Genes, _population(op).Genes), _colors)
            Else
                children(i) = New Chromosome(_population(i))
            End If
        Next i

        _population = children
    End Sub

    Private Function Crossover(ByVal mother() As Integer, ByVal father() As Integer) As Integer()
        'Crossover with Two-point
        'http://en.wikipedia.org/wiki/Crossover_(genetic_algorithm)#Two-point_crossover
        Dim child(mother.Length - 1) As Integer
        Dim cutPointA = _randomGenerator.[Next](mother.Length - 1)
        Dim cutPointB = 0

        For i As Integer = 0 To child.Length - 1
            While (cutPointB <= cutPointA)
                cutPointB = _randomGenerator.[Next](child.Length)
            End While

            For j As Integer = 0 To cutPointA
                child(j) = mother(j)
            Next

            For k As Integer = cutPointA + 1 To cutPointB
                child(k) = father(k)
            Next

            For l As Integer = cutPointB + 1 To _nodes - 1
                child(l) = mother(l)
            Next
        Next i

        Return child
    End Function

    Private Sub MutatePopulation()
        For Each aPopulation As Chromosome In _population
            aPopulation.MinimizeErrors(_graph, Me._mutProb)
        Next aPopulation
    End Sub

    Private Function FindFittest() As Chromosome
        Dim fittest As Chromosome = _population(0)

        For i As Integer = 1 To _population.Length - 1
            fittest = If(_population(i).Fitness < fittest.Fitness, _population(i), fittest)
        Next i

        Return fittest
    End Function

    Private Function FindWorst() As Chromosome
        Dim fittest As Chromosome = _population(0)

        For i As Integer = 1 To _population.Length - 1
            fittest = If(_population(i).Fitness > fittest.Fitness, _population(i), fittest)
        Next i

        Return fittest
    End Function

    Private Function FindAvg() As Double
        Dim avg As Double = 0
        For Each population1 As Chromosome In _population
            avg += population1.Fitness
        Next population1

        Return avg / _population.Length
    End Function

End Class
