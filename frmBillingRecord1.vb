Imports System.Data.SqlClient

Imports System.IO

Public Class frmBillingRecord1

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.ID),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ProductCharges, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillInvoiceNo()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Report need" Then

                End If
                If lblSet.Text = "Billing1" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmBilling1.Show()
                    Me.Hide()
                    frmBilling1.txtID.Text = dr.Cells(0).Value.ToString()
                    frmBilling1.txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmBilling1.dtpInvoiceDate.Text = dr.Cells(2).Value.ToString()
                    frmBilling1.txtS_ID.Text = dr.Cells(3).Value.ToString()
                    frmBilling1.txtServiceCode.Text = dr.Cells(4).Value.ToString()
                    frmBilling1.txtCID.Text = dr.Cells(5).Value.ToString()
                    frmBilling1.txtCustomerID.Text = dr.Cells(6).Value.ToString()
                    frmBilling1.txtCustomerName.Text = dr.Cells(7).Value.ToString()
                    frmBilling1.txtRepairCharges.Text = dr.Cells(8).Value.ToString()
                    frmBilling1.txtUpfront.Text = dr.Cells(9).Value.ToString()
                    frmBilling1.txtProductCharges.Text = dr.Cells(10).Value.ToString()
                    frmBilling1.txtServiceTaxPer.Text = dr.Cells(11).Value.ToString()
                    frmBilling1.txtServiceTaxAmount.Text = dr.Cells(12).Value.ToString()
                    'frmBilling1.txtContactNo.Text = dr.Cells(9).Value.ToString()
                    'frmBilling1.txtProductID.Text = dr.Cells(10).Value.ToString()
                    'frmBilling.txtProductCode.Text = dr.Cells(11).Value.ToString()
                    'frmBilling.txtProductName.Text = dr.Cells(12).Value.ToString()
                    'frmBilling.txtSellingPrice.Text = dr.Cells(13).Value.ToString()
                    'frmBilling.txtQty.Text = dr.Cells(14).Value.ToString()
                    'frmBilling.txtAmount.Text = dr.Cells(15).Value.ToString()
                    'frmBilling.txtDiscountPer.Text = dr.Cells(16).Value.ToString()
                    'frmBilling.txtDiscountAmount.Text = dr.Cells(17).Value.ToString()
                    'frmBilling.txtVAT.Text = dr.Cells(18).Value.ToString()
                    'frmBilling.txtVATAmount.Text = dr.Cells(19).Value.ToString()
                    'frmBilling.txtTotalAmount.Text =dr.Cells(20).Value.ToString()
                    frmBilling1.txtGrandTotal.Text = dr.Cells(13).Value.ToString()
                    frmBilling1.txtTotalPayment.Text = dr.Cells(14).Value.ToString()
                    frmBilling1.txtPaymentDue.Text = dr.Cells(15).Value.ToString()
                    frmBilling1.txtRemarks.Text = dr.Cells(16).Value.ToString()
                    frmBilling1.btnSave.Enabled = False
                    frmBilling1.btnUpdate.Enabled = True
                    frmBilling1.btnPrint.Enabled = True
                    frmBilling1.btnDelete.Enabled = True
                    frmBilling1.lblSet.Text = ""
                    frmBilling1.btnAdd.Enabled = False
                    frmBilling1.btnSaveNew.Enabled = False
                    frmBilling1.btnUpdateNew.Enabled = True
                    frmBilling1.btnPrintNew.Enabled = True
                    frmBilling1.btnDeleteNew.Enabled = True
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT P.ProductCode,P.ProductName,P.CostPrice,P.SellingPrice,IP.Margin,IP.Qty,IP.Amount,IP.DiscountPer,IP.Discount,IP.VATPer,IP.VAT,IP.TotalAmount FROM Product P,Invoice1_Product IP WHERE P.PID = IP.ProductID AND IP.InvoiceID = @d1"
                    cmd = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmBilling1.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmBilling1.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                    End While
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql_1 As String = "SELECT IY.PaymentMode,IY.TotalPaid,IY.PaymentDate FROM Invoice1_Payment IY, InvoiceInfo1 II WHERE II.Inv_ID = IY.InvoiceID AND IY.InvoiceID = @d1"
                    cmd = New SqlCommand(sql_1, con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmBilling1.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmBilling1.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2))
                    End While
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select RTRIM(CustomerType) from Customer where ID=" & dr.Cells(3).Value & ""
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then
                        frmQuotation.txtCustomerType.Text = rdr.GetValue(0)
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                        Exit Sub
                    End If
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub fillInvoiceNo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo1", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbInvoiceNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbInvoiceNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbInvoiceNo.Text = ""
        txtCustomerName.Text = ""
        fillInvoiceNo()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Today
        Getdata()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ProductCharges, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ProductCharges, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceNo='" & cmbInvoiceNo.Text & "' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ProductCharges, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ProductCharges, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and Name like '%" & txtCustomerName.Text & "%' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbInvoiceNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbInvoiceNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
