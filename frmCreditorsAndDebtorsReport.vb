Imports System.Data.SqlClient


Public Class frmCreditorsAndDebtorsReport
    Sub fillCity()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(City) FROM Supplier Union Select Distinct RTRIM(City) from Customer", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCity.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCity.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditors.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Supplier.SupplierID, Supplier.Name, Supplier.City, Supplier.ContactNo,Pur.SP-Pay.SPay FROM Supplier LEFT OUTER JOIN(Select SupplierID,IsNULL(Sum(PaymentDue)-Sum(PreviousDue),0) as SP from Stock group by SupplierID) Pur ON Supplier.ID = Pur.SupplierID LEFT OUTER JOIN (Select SupplierID,IsNULL(Sum(Amount),0) as SPay from Payment group by SupplierID) Pay ON Supplier.ID = Pay.SupplierID where Pur.SP-Pay.SPay > 0  ORDER BY Supplier.Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Creditors.xml")
            Dim rpt As New rptCreditors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnDebtors.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select CustomerID,Name,City,ContactNo,Sum(Balance) as [Balance] From (Select Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo,Sum(Balance) as [Balance] from Customer,InvoiceInfo where Customer.ID=InvoiceInfo.CustomerID group by Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo having (Sum(Balance) > 0)  Union All Select Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo,Sum(Balance) as [Balance] from Customer,InvoiceInfo1,Service where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID group by Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo having (Sum(Balance) > 0)) As Customer Group By CustomerID,Name,City,ContactNo Order by Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Debtors.xml")
            Dim rpt As New rptDebtors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmStockInAndOutReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillCity()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbCity.Text)) = 0 Then
                MessageBox.Show("Please Select City", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCity.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select CustomerID,Name,City,ContactNo,Sum(Balance) as [Balance] From (Select Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo,Sum(Balance) as [Balance] from Customer,InvoiceInfo where Customer.ID=InvoiceInfo.CustomerID and City=@d1 group by Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo having (Sum(Balance) > 0)  Union All Select Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo,Sum(Balance) as [Balance] from Customer,InvoiceInfo1,Service where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID group by Customer.CustomerID,Customer.Name,Customer.City,Customer.ContactNo having (Sum(Balance) > 0)) As Customer Group By CustomerID,Name,City,ContactNo order by Name", con)
            cmd.Parameters.AddWithValue("@d1", cmbCity.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Debtors.xml")
            Dim rpt As New rptDebtors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            If Len(Trim(cmbCity.Text)) = 0 Then
                MessageBox.Show("Please Select City", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCity.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Supplier.SupplierID, Supplier.Name, Supplier.City, Supplier.ContactNo,Pur.SP-Pay.SPay FROM Supplier LEFT OUTER JOIN(Select SupplierID,IsNULL(Sum(PaymentDue)-Sum(PreviousDue),0) as SP from Stock group by SupplierID) Pur ON Supplier.ID = Pur.SupplierID LEFT OUTER JOIN((Select SupplierID,IsNULL(Sum(Amount),0) as SPay from Payment group by SupplierID)) Pay ON Supplier.ID = Pay.SupplierID where Pur.SP-Pay.SPay > 0 and City=@d1  order by Supplier.Name", con)
            cmd.Parameters.AddWithValue("@d1", cmbCity.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Creditors.xml")
            Dim rpt As New rptCreditors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        cmbCity.Text = ""
    End Sub
End Class
