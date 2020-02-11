Module Clase1
	Dim variable1 As Integer=10/5+3
	Public Sub metodo1()
		Console.WriteLine("el factorial de 5" & "es: " + factorial(variable1))
		variable2 As Integer = Console.ReadLine
		Console.WriteLine("------------------------------")
		Console.WriteLine("El factorial de "&variable2&" es: "+ factorial(variable2))
	End Sub
	Public Function factorial(ByVal num As Integer) As Integer
		If num = 0 Then
			Return 1
		Else
			Return num*factorial(num-1)
		End If
	End Function

End Module
