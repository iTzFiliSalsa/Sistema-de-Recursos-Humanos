Imports System.IO
Imports MySql.Data.MySqlClient

Public Class MenuPrincipal

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim hijo As Perfil = New Perfil()
        AbrirFormEnPanel(hijo)
    End Sub
    Private Nombre As String
    Private Email As String
    Public cnn As MySqlConnection
    Public Property FullName() As String
        Get
            Return Me.Nombre
        End Get
        Set(ByVal Value As String)
            Me.Nombre = Value
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return Me.Email
        End Get
        Set(ByVal Value As String)
            Me.Email = Value
        End Set
    End Property
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Nombre
        Try
            Dim StrConexion As String = "server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none"
            Dim Sql As String = "select * from adicional where email='" & Email & "';"
            Dim lector As MySqlDataReader
            cnn = New MySqlConnection(StrConexion)
            cnn.Open()
            If cnn.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, cnn)
                lector = Comando.ExecuteReader
                While lector.Read
                    Imag = lector("imagen")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                End While
            End If
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Button11.Text = Nombre
        Dim hijo As Iconos = New Iconos()
        AbrirFormEnPanel(hijo)
    End Sub
    Public Sub Abrir()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hijo As Iconos = New Iconos()
        AbrirFormEnPanel(hijo)
    End Sub
    Private Sub AbrirFormEnPanel(ByVal formpanel)
        If (Me.Panel4.Controls.Count > 0) Then
            Me.Panel4.Controls.RemoveAt(0)
        End If
        Dim fp As Form = New Form()
        fp = formpanel
        fp.TopLevel = False
        fp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fp.Dock = DockStyle.Fill
        Panel4.Controls.Add(fp)
        Me.Panel4.Tag = fp
        fp.Show()
    End Sub

    Private Sub Panel4_Resize(sender As Object, e As EventArgs) Handles Panel4.Resize

    End Sub

    Private Sub MenuPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Iconos.Panel1.Height = Me.Height - 200
        Iconos.Panel1.Width = Me.Width - 50
        Panel4.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim hijo As Editar = New Editar()
        AbrirFormEnPanel(hijo)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim file As New OpenFileDialog()
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(file.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        Try
            Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
            Dim consulta As New MySqlCommand("update adicional set imagen=?imagen where email='" & Email & "'", oConexion)
            Dim Imag As Byte()
            Imag = Imagen_Bytes(Me.PictureBox1.Image)
            consulta.Parameters.AddWithValue("?imagen", Imag)
            oConexion.Open()
            consulta.ExecuteNonQuery()
            oConexion.Close()
            MessageBox.Show("Usuario guardado en la base de datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim hijo As Perfil = New Perfil()
        AbrirFormEnPanel(hijo)
    End Sub
End Class