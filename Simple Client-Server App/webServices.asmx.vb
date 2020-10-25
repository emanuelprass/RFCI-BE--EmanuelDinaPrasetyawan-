Imports System.Web.Services
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Net
Imports System.Net.Sockets
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<System.Web.Script.Services.ScriptService>
<ToolboxItem(False)>
Public Class webServices
	Inherits System.Web.Services.WebService

	<WebMethod()>
	Public Function HelloWorld(X_RANDOM As String, counter As String) As String
		Dim perfs = New List(Of Class1)()


		Dim perf = New Class1 With {
			.xRandom = X_RANDOM,
			.counter = CInt(counter)
		}

		perfs.Add(perf)

		Dim js = New JavaScriptSerializer()
		js.MaxJsonLength = Int32.MaxValue

		createLogFile(X_RANDOM, counter)

		Return js.Serialize(perfs)

	End Function

	Private Function createLogFile(X_RANDOM As String, counter As Integer) As Boolean
		Dim path As String = Server.MapPath("~/Log/server.log")
		'Dim path As String = "C:\Users\Farid\Documents\AOP\TestAJAX\TestAJAX\Files\server.log"

		Dim dt As String = DateTime.Now.ToString("O")
		Dim result As Boolean = True

		Dim ip As String = ""

		Try
			ip = getServerIP()

			Dim text As String = "[" & dt & "] Success: POST http://" & ip & " {""counter"": " & counter.ToString() & ", ""X-RANDOM"":" & X_RANDOM & "}"

			If (Not Directory.Exists(path)) Then
				Directory.CreateDirectory(Server.MapPath("~/Log"))
			End If

			If (Not File.Exists(path)) Then
				File.Create(path).Dispose()
			End If

			If File.Exists(path) Then
				Try
					Dim objWriter As New System.IO.StreamWriter(path, True)
					objWriter.WriteLine(text)
					objWriter.Close()
					objWriter.Dispose()
				Catch
				End Try
			End If

		Catch ex As Exception
			result = False
		End Try
		Return result
	End Function

	Private Function getServerIP() As String
		Dim host = Dns.GetHostEntry(Dns.GetHostName())
		Dim result As String = ""

		For Each ip In host.AddressList
			If ip.AddressFamily = AddressFamily.InterNetwork Then
				result = ip.ToString()
			End If
		Next

		Return result
	End Function


End Class