Imports System.Data.SqlClient


Public Class frmCreditTermsStatementsReport

    Dim a, b, c As String
    Dim num1, num2, num3, num4, num5, num6 As Decimal
    Sub fillCustomer()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT RTRIM(Name) FROM Customer where CustomerType='Regular'", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCustomerName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCustomerName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        cmbCustomerName.Text = ""
        txtCustomerID.Text = ""
        DateTimePicker2.Value = Today
        DateTimePicker1.Value = Today
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbCustomerName.Text)) = 0 Then
                MessageBox.Show("Please Select Customer Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCustomerName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from InvoiceInfo,Invoice_Payment,Customer where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.CustomerID=Customer.ID and Customer.CustomerID=@d1 and InvoiceDate >=@d2 and InvoiceDate < @d3 and PaymentMode in ('Credit terms - 7 days','Credit terms - 14 days','Credit terms - 30 days','Credit terms - 45 days','Credit terms - 60 days','Credit terms - 90 days')"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtCustomerID.Text)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT InvoiceNo,InvoiceDate,PaymentMode, IsNull((Balance),0) FROM InvoiceInfo,Invoice_Payment,Customer where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.CustomerID=Customer.ID and Customer.CustomerID=@d1 and InvoiceDate >=@d2 and InvoiceDate < @d3 and PaymentMode in ('Credit terms - 7 days','Credit terms - 14 days','Credit terms - 30 days','Credit terms - 45 days','Credit terms - 60 days','Credit terms - 90 days') order by InvoiceDate", con)
            cmd.Parameters.AddWithValue("@d1", txtCustomerID.Text)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CreditTermsStatementsByCustomer1.xml")
            Dim rpt As New rptCreditTermsStatementsByCustomer
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", txtCustomerID.Text)
            rpt.SetParameterValue("p4", cmbCustomerName.Text)
            rpt.SetParameterValue("p5", a)
            rpt.SetParameterValue("p6", b)
            rpt.SetParameterValue("p7", c)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSalesReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillCustomer()
    End Sub

    Private Sub cmbSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try
            a = ""
            b = ""
            c = ""
            txtCustomerID.Text = ""
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CustomerID),RTRIM(Address),RTRIM(City),RTRIM(ContactNo) FROM Customer WHERE Name=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbCustomerName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCustomerID.Text = rdr.GetValue(0)
                a = rdr.GetValue(1)
                b = rdr.GetValue(2)
                c = rdr.GetValue(3)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from InvoiceInfo,Invoice_Payment,Customer where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.CustomerID=Customer.ID and InvoiceDate >=@d2 and InvoiceDate < @d3 and PaymentMode in ('Credit terms - 7 days','Credit terms - 14 days','Credit terms - 30 days','Credit terms - 45 days','Credit terms - 60 days','Credit terms - 90 days')"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT InvoiceNo,InvoiceDate,PaymentMode,Customer.CustomerID,Name, IsNull((Balance),0) FROM InvoiceInfo,Invoice_Payment,Customer where InvoiceInfo.Inv_ID=Invoice_Payment.InvoiceID and InvoiceInfo.CustomerID=Customer.ID and InvoiceDate >=@d2 and InvoiceDate < @d3 and PaymentMode in ('Credit terms - 7 days','Credit terms - 14 days','Credit terms - 30 days','Credit terms - 45 days','Credit terms - 60 days','Credit terms - 90 days') order by InvoiceDate", con)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CreditTermsStatements.xml")
            Dim rpt As New rptCreditTermsStatements
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
