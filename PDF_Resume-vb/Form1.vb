Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Newtonsoft.Json
Public Class Form1
    Dim GetJsonFile As String = File.ReadAllText("Information.json")
    Dim JsonOutput As MyInformation = JsonConvert.DeserializeObject(Of MyInformation)(GetJsonFile)

    Private Sub BtnCreatePDF_Click(sender As Object, e As EventArgs) Handles BtnCreatePDF.Click
        Dim GeneratedPDF As Document = New Document()
        PdfWriter.GetInstance(GeneratedPDF, New FileStream("Correo, Czr B.pdf", FileMode.Create))
        GeneratedPDF.Open()

        Dim Name As Paragraph = New Paragraph(JsonOutput.Name & vbLf & vbLf)
        Name.Font.Size = 30
        Name.Alignment = Element.ALIGN_CENTER
        GeneratedPDF.Add(Name)

        Dim Obj As Paragraph = New Paragraph("OBJECTIVES" & vbLf & vbLf)
        Dim Objectives As Paragraph = New Paragraph(JsonOutput.Objectives & vbLf & vbLf)

        Objectives.Font.Size = 12
        Objectives.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Objectives)

        Dim Data As Paragraph = New Paragraph("DATA" & vbLf & vbLf)
        Data.Font.Size = 20
        Data.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Data)

        Dim ContactNumber As Paragraph = New Paragraph(JsonOutput.ContactNumber)
        ContactNumber.Font.Size = 12
        ContactNumber.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(ContactNumber)

        Dim Address As Paragraph = New Paragraph(JsonOutput.Address)
        Address.Font.Size = 12
        Address.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Address)

        Dim Age As Paragraph = New Paragraph(JsonOutput.Age)
        Age.Font.Size = 12
        Age.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Age)

        Dim Email As Paragraph = New Paragraph(JsonOutput.Email & vbLf & vbLf)
        Email.Font.Size = 12
        Email.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Email)

        Dim Educ As Paragraph = New Paragraph("EDUCATION" & vbLf & vbLf)
        Educ.Font.Size = 20
        Educ.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Educ)

        Dim Education As Paragraph = New Paragraph(JsonOutput.Education & vbLf & vbLf)
        Education.Font.Size = 12
        Education.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Education)

        Dim Skl As Paragraph = New Paragraph("SKILLS" & vbLf & vbLf)
        Skl.Font.Size = 20
        Skl.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Skl)

        Dim Skills As Paragraph = New Paragraph(JsonOutput.Skills & vbLf & vbLf)
        Skills.Font.Size = 12
        Skills.Alignment = Element.ALIGN_LEFT
        GeneratedPDF.Add(Skills)

        Dim Name2 As Paragraph = New Paragraph(JsonOutput.Name2)
        Name2.Font.Size = 18
        Name2.Alignment = Element.ALIGN_RIGHT
        GeneratedPDF.Add(Name2)


        GeneratedPDF.Close()
        MsgBox("PDF Generated")
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Dim AppExit = MessageBox.Show("Are you sure to exit the application?", "PDF Generated", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If AppExit = vbYes Then
            Application.Exit()
        End If
    End Sub
    Public Class MyInformation

        Public Property Name As String
        Public Property Objectives As String
        Public Property ContactNumber As String
        Public Property Address As String
        Public Property Age As String
        Public Property Email As String
        Public Property Education As String
        Public Property Skills As String
        Public Property Name2 As String
    End Class

End Class
