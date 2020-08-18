Imports System.Data.SqlClient

Imports System.IO
Public Class frmBpBillingRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            'cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID order by InvoiceDate", con)
            cmd = New SqlCommand("SELECT II.Inv_ID,RTRIM(II.InvoiceNo),II.InvoiceDate,S.SM_ID,RTRIM(S.SalesMan_ID),RTRIM(S.Name),C.ID,RTRIM(C.CustomerID),RTRIM(C.Name),RTRIM(C.ContactNo),IP.ProductID,RTRIM(P.ProductCode),RTRIM(P.ProductName),IP.SellingPrice,IP.Qty,IP.Amount,IP.DiscountPer,IP.Discount,IP.VATPer,IP.VAT,IP.TotalAmount,IY.PaymentMode,IY.TotalPaid,IY.PaymentDate,II.GrandTotal,II.TotalPaid,II.Balance,RTRIM(II.Remarks)FROM Customer C,InvoiceInfo II,Salesman S,Invoice_Product IP,Product P,Invoice_Payment IY WHERE C.ID = II.CustomerID AND S.SM_ID = II.SalesmanID AND IP.InvoiceID = II.Inv_ID AND IP.ProductID = P.PID AND IY.InvoiceID = II.Inv_ID AND II.InvoiceNo LIKE '%INVBP%' ORDER BY II.InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20), rdr(21), rdr(22), rdr(23), rdr(24), rdr(25), rdr(26), rdr(27))
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

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmBPBilling.Show()
                Me.Hide()
                frmBPBilling.txtID.Text = dr.Cells(0).Value.ToString()
                frmBPBilling.txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                frmBPBilling.dtpInvoiceDate.Text = dr.Cells(2).Value.ToString()
                frmBPBilling.txtSM_ID.Text = dr.Cells(3).Value.ToString()
                frmBPBilling.txtSalesmanId.Text = dr.Cells(4).Value.ToString()
                frmBPBilling.txtSalesmanName.Text = dr.Cells(5).Value.ToString()
                frmBPBilling.txtCID.Text = dr.Cells(6).Value.ToString()
                frmBPBilling.txtCustomerID.Text = dr.Cells(7).Value.ToString()
                frmBPBilling.txtCustomerName.Text = dr.Cells(8).Value.ToString()
                frmBPBilling.txtContactNo.Text = dr.Cells(9).Value.ToString()
                frmBPBilling.txtProductID.Text = dr.Cells(10).Value.ToString()
                'frmBPBilling.txtProductCode.Text = dr.Cells(11).Value.ToString()
                'frmBPBilling.txtProductName.Text = dr.Cells(12).Value.ToString()
                'frmBPBilling.txtSellingPrice.Text = dr.Cells(13).Value.ToString()
                'frmBPBilling.txtQty.Text = dr.Cells(14).Value.ToString()
                'frmBPBilling.txtAmount.Text = dr.Cells(15).Value.ToString()
                'frmBPBilling.txtDiscountPer.Text = dr.Cells(16).Value.ToString()
                'frmBPBilling.txtDiscountAmount.Text = dr.Cells(17).Value.ToString()
                'frmBPBilling.txtVAT.Text = dr.Cells(18).Value.ToString()
                'frmBPBilling.txtVATAmount.Text = dr.Cells(19).Value.ToString()
                'frmBPBilling.txtTotalAmount.Text =dr.Cells(20).Value.ToString()
                frmBPBilling.txtGrandTotal.Text = dr.Cells(24).Value.ToString()
                frmBPBilling.txtTotalPayment.Text = dr.Cells(25).Value.ToString()
                frmBPBilling.txtPaymentDue.Text = dr.Cells(26).Value.ToString()
                frmBPBilling.txtRemarks.Text = dr.Cells(27).Value.ToString()
                frmBPBilling.btnSave.Enabled = False
                frmBPBilling.btnUpdate.Enabled = True
                frmBPBilling.btnPrint.Enabled = True
                frmBPBilling.btnDelete.Enabled = True
                frmBPBilling.lblSet.Text = "Not Allowed"
                frmBPBilling.btnAdd.Enabled = False
                frmBPBilling.btnSaveNew.Enabled = False
                frmBPBilling.btnUpdateNew.Enabled = True
                frmBPBilling.btnPrintNew.Enabled = True
                frmBPBilling.btnDeleteNew.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT P.OProductCode,P.OProductName,P.CostPrice,P.SellingPrice,IP.Margin,IP.Qty,IP.Amount,IP.DiscountPer,IP.Discount,IP.VATPer,IP.VAT,IP.TotalAmount FROM OurProduct P, Invoice_Product IP WHERE P.OPID = IP.ProductID AND IP.InvoiceID = @d1"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmBPBilling.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmBPBilling.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql_1 As String = "SELECT IY.PaymentMode,IY.TotalPaid,IY.PaymentDate FROM Invoice_Payment IY, InvoiceInfo II WHERE II.Inv_ID = IY.InvoiceID AND IY.InvoiceID = @d1"
                cmd = New SqlCommand(sql_1, con)
                cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmBPBilling.DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    frmBPBilling.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2))
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
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo WHERE InvoiceNo LIKE '%INVBP%'", con)
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
        txtSalesman.Text = ""
        fillInvoiceNo()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Today
        Getdata()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID and InvoiceDate between @d1 and @d2 AND InvoiceNo LIKE '%INVBP%' order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID and InvoiceNo='" & cmbInvoiceNo.Text & "' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID and InvoiceDate between @d1 and @d2 and Balance > 0 and and InvoiceNo like '%INVBP%' order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID and Customer.Name like '%" & txtCustomerName.Text & "%' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbInvoiceNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbInvoiceNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub txtSalesman_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesman.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate,SM_ID, RTRIM(Salesman_ID),RTRIM(Salesman.Name),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo), GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo.Remarks) from Customer,InvoiceInfo,Salesman where Customer.ID=InvoiceInfo.CustomerID and Salesman.SM_ID=InvoiceInfo.SalesmanID and Salesman.Name like '%" & txtSalesman.Text & "%' order by InvoiceDate", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class