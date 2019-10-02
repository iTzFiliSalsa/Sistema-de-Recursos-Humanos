Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class Editar
    Private DES As New TripleDESCryptoServiceProvider
    Private hashmd5 As New MD5CryptoServiceProvider
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles apellidos.TextChanged


    End Sub

    Private Sub Editar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim consulta As New MySqlCommand("Select * from usuarios where email='" & MenuPrincipal.Correo & "'", oConexion)
        Dim extra As New MySqlCommand("Select * from adicional where email='" & MenuPrincipal.Correo & "'", oConexion)
        Dim leer As MySqlDataReader
        Dim sw As Boolean = False
        Try
            oConexion.Open()
            leer = consulta.ExecuteReader
            While leer.Read()
                nombre.Text = leer.GetString(1)
                apellidos.Text = leer.GetString(2)
                telefono.Text = leer.GetString(4)
            End While
            leer.Close()
            leer = extra.ExecuteReader
            While leer.Read()
                sexo.Text = leer.GetString(1)
                pais.Text = leer.GetString(2)
                nacimiento.Text = leer.GetString(3)
                curp.Text = leer.GetString(4)
                rfc.Text = leer.GetString(5)
            End While
            oConexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If contraseña1.Text = contraseña2.Text Then
            If (general(nombre.Text, apellidos.Text, telefono.Text, contraseña1.Text)) Then
            End If
        End If
    End Sub
    Function general(ByVal nombres As String, ByVal apellido As String, ByVal telefonos As String, ByVal contraseñas As String)
        Dim rw As Boolean = True
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim consulta As New MySqlCommand("update usuarios set nombre='" & nombre.Text & "', apellido='" & apellidos.Text & "', telefono='" & telefono.Text & "', contraseña=md5('" & contraseña1.Text & "') where email='" & MenuPrincipal.Correo & "';", oConexion)
        Try
            oConexion.Open()
            consulta.ExecuteNonQuery()
            rw = True
            MessageBox.Show("Usuario Actualizado con exito", "Exito")
            MenuPrincipal.Button11.Text = nombre.Text
            oConexion.Close()
        Catch ex As Exception
            rw = False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (adicional(sexo.Text, pais.Text, nacimiento.Text, curp.Text, rfc.Text)) Then
        End If
    End Sub
    Function adicional(ByVal nombres As String, ByVal apellido As String, ByVal telefonos As String, ByVal contraseñas As String, ByVal rfcs As String)
        Dim rw As Boolean = True
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim consulta As New MySqlCommand("update adicional set sexo='" & nombres & "', pais='" & apellido & "', fecha='" & telefonos & "', curp='" & contraseñas & "',rfc='" & rfcs & "' where email='" & MenuPrincipal.Correo() & "';", oConexion)
        Try
            oConexion.Open()
            consulta.ExecuteNonQuery()
            rw = True
            MessageBox.Show("Informacion actualizada con exito", "Exito")
            MenuPrincipal.Button11.Text = nombre.Text
            oConexion.Close()
        Catch ex As Exception
            rw = False
            MessageBox.Show(ex.Message)
        End Try
    End Function
End Class