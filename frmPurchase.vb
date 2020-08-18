Imports System.Data.SqlClient
Imports System.IO

Public Class frmPurchase
    Dim str As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Stock ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtST_ID.Text = GenerateID()
            txtInvoiceNo.Text = "PO-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtDiscPer.Text)) = 0 Then
            MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscPer.Focus()
            Exit Sub
        End If
        If Len(Trim(txtFreightCharges.Text)) = 0 Then
            MessageBox.Show("Please enter freight charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFreightCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOtherCharges.Text)) = 0 Then
            MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtherCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoundOff.Text)) = 0 Then
            MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoundOff.Focus()
            Exit Sub
        End If
        If cmbPurchaseType.SelectedIndex = 0 Then
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) = 0 Then
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
        End If
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select InvoiceNo from Stock where InvoiceNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtInvoiceNo.Text = ""
                txtInvoiceNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Stock(ST_ID, InvoiceNo, Date,PurchaseType, SupplierID, SubTotal, DiscountPer, Discount, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPurchaseType.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtDisc.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtPreviousDue.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtFreightCharges.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@d13", Val(txtRoundOff.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtTotalPaid.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtBalance.Text))
            cmd.Parameters.AddWithValue("@d17", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////'
            con = New SqlConnection(cs)
            con.Open()
            Dim purchase_stock As String = "insert into STOCK_PURCHASE(ST_ID, InvoiceNo, Date,PurchaseType, SupplierID, SubTotal, DiscountPer, Discount, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
            cmd = New SqlCommand(purchase_stock)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPurchaseType.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtDisc.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtPreviousDue.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtFreightCharges.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@d13", Val(txtRoundOff.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtTotalPaid.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtBalance.Text))
            cmd.Parameters.AddWithValue("@d17", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////'
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Stock_Product(StockID,ProductID,Qty,Price,TotalAmount) VALUES (" & txtST_ID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(5).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1"
                    cmd = New SqlCommand(ctx)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty = Qty + " & row.Cells(4).Value & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()

                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into Temp_Stock(ProductID,Qty) VALUES (@d1,@d2)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            If cmbPurchaseType.SelectedIndex = 1 Then
                SupplierLedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 0 Then
                SupplierLedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
                SupplierLedgerSave(dtpDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment", Val(txtTotalPaid.Text), 0, txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 1 Then
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
            End If
            If cmbPurchaseType.SelectedIndex = 0 Then
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text)
                LedgerSave(dtpDate.Value.Date, "Cash Account", txtInvoiceNo.Text, "Payment to " & txtSupplierName.Text & "", Val(txtTotalPaid.Text), 0, txtSupplierID.Text)
            End If
            RefreshRecords()
            LogFunc(lblUser.Text, "added the new Purchase having Invoice No. '" & txtInvoiceNo.Text & "'")
            MessageBox.Show("Successfully saved", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        frmSupplierRecord.lblSet.Text = "Stock Entry"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmProductRecord.lblSet.Text = "Stock"
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub
    Sub Reset()
        txtAddress.Text = ""
        txtBalance.Text = ""
        txtCity.Text = ""
        txtContactNo.Text = ""
        txtDiscPer.Text = "0.00"
        txtDisc.Text = "0.00"
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtSup_ID.Text = ""
        txtFreightCharges.Text = "0.00"
        txtGrandTotal.Text = ""
        txtInvoiceNo.Text = ""
        txtOtherCharges.Text = "0.00"
        txtPreviousDue.Text = "0.00"
        txtRemarks.Text = ""
        txtRoundOff.Text = "0.00"
        txtTotalPaid.Text = "0.00"
        cmbPurchaseType.SelectedIndex = 1
        dtpDate.Text = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        lblBalance.Text = "0.00"
        txtTotalPaid.ReadOnly = True
        txtTotalPaid.Enabled = False
        DataGridView1.Rows.Clear()
        btnSelection.Enabled = True
        Clear()
        auto()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(1).Value = txtProductCode.Text Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = txtProductCode.Text
                    r.Cells(2).Value = txtProductName.Text
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
                    r.Cells(3).Value = txtPricePerQty.Text
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
            Dim j As Double = 0
            j = SubTotal()
            j = Math.Round(j, 2)
            txtSubTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(5).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Compute()
            btnRemove.Enabled = False
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute()
        num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
        num6 = Math.Round(num6, 2)
        txtDisc.Text = num6
        num7 = Val(txtSubTotal.Text) - num6
        num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text)
        num1 = Math.Round(num1, 2)
        txtTotal.Text = num1
        num2 = Math.Round(num1, 1)
        num3 = num2 - num1
        num3 = Math.Round(num3, 2)
        txtRoundOff.Text = num3
        num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
        num4 = Math.Round(num4, 2)
        txtGrandTotal.Text = num4
        num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
        num5 = Math.Round(num5, 2)
        txtBalance.Text = num5
    End Sub

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            btnRemove.Enabled = True
        End If

        'r.Cells(0).Value = txtProductID.Text
        'r.Cells(1).Value = txtProductCode.Text
        'r.Cells(2).Value = txtProductName.Text
        'r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
        'r.Cells(3).Value = txtPricePerQty.Text
        'r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
        Dim row As DataGridViewRow = Me.DataGridView1.SelectedRows.Item(0)
        Me.txtProductCode.Text = (row.Cells.Item(1).Value)
        Me.txtProductID.Text = (row.Cells.Item(0).Value)
        Me.txtProductName.Text = (row.Cells.Item(2).Value)
        Me.txtPricePerQty.Text = (row.Cells.Item(3).Value)
        Me.txtQty.Text = (row.Cells.Item(4).Value)
        Me.txtTotalAmount.Text = (row.Cells.Item(5).Value)
        btnAdd.Enabled = False
        btnListUpdate.Enabled = True
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPricePerQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub


    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub

    Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPricePerQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPricePerQty.Text
            Dim selectionStart = Me.txtPricePerQty.SelectionStart
            Dim selectionLength = Me.txtPricePerQty.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalPayment_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtTotalPayment_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPurchaseRecord.lblSet.Text = "Purchase"
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Sub GetSupplierBalance()
        Try
            num1 = 0
            num2 = 0
            num3 = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT isNULL(Sum(PaymentDue),0)-IsNull(Sum(PreviousDue),0) from Supplier,STOCK_PURCHASE where Supplier.ID=STOCK_PURCHASE.SupplierID and Supplier.ID=@d1 group By Supplier.ID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT isNULL(Sum(Amount),0) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Supplier.ID=@d1 group By Supplier.ID"
            cmd = New SqlCommand(sql1, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num2 = rdr.GetValue(0)
            End If
            con.Close()
            num3 = num1 - num2
            num3 = Math.Round(num3, 2)
            lblBalance.Text = num3
            If Val(lblBalance.Text) >= 0 Then
                str = "CR"
            ElseIf Val(lblBalance.Text < 0) Then
                str = "DR"
            End If
            txtPreviousDue.Text = num3
            lblBalance.Text = Math.Abs(Val(lblBalance.Text))
            lblBalance.Text = (lblBalance.Text & " " & str).ToString()
            Compute()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierInfo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier where ID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtSupplierID.Text = rdr.GetValue(0)
                txtSupplierName.Text = rdr.GetValue(1)
                txtAddress.Text = rdr.GetValue(2)
                txtCity.Text = rdr.GetValue(3)
                txtContactNo.Text = rdr.GetValue(4)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierBalance1()
        Try
            num1 = 0
            num2 = 0
            num3 = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT isNULL(Sum(PaymentDue),0)-IsNull(Sum(PreviousDue),0) from Supplier,STOCK_PURCHASE where Supplier.ID=STOCK_PURCHASE.SupplierID and Supplier.ID=@d1 group By Supplier.ID"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT isNULL(Sum(Amount),0) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Supplier.ID=@d1 group By Supplier.ID"
            cmd = New SqlCommand(sql1, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num2 = rdr.GetValue(0)
            End If
            con.Close()
            num3 = num1 - num2
            num3 = Math.Round(num3, 2)
            lblBalance.Text = num3
            If Val(lblBalance.Text) >= 0 Then
                str = "CR"
            ElseIf Val(lblBalance.Text < 0) Then
                str = "DR"
            End If
            lblBalance.Text = Math.Abs(Val(lblBalance.Text))
            lblBalance.Text = (lblBalance.Text & " " & str).ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Stock where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty = Qty - " & row.Cells(4).Value & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
            Next
            If RowsAffected > 0 Then
                LedgerDelete(txtInvoiceNo.Text)
                SupplierLedgerDelete(txtInvoiceNo.Text)
                LogFunc(lblUser.Text, "deleted the purchase record having Invoice No. '" & txtInvoiceNo.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                RefreshRecords()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmSupplierRecord.lblSet.Text = "Purchase"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Compute()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtFreightCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFreightCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtPreviousDue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPreviousDue.TextChanged
        Compute()
    End Sub

    Private Sub txtRoundOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRoundOff.TextChanged
        Compute()
    End Sub

    Private Sub txtTotalPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub cmbPurchaseType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPurchaseType.SelectedIndexChanged
        If cmbPurchaseType.SelectedIndex = 1 Then
            txtTotalPaid.Text = "0.00"
            txtTotalPaid.ReadOnly = True
            txtTotalPaid.Enabled = False
        Else
            txtTotalPaid.Text = "0.00"
            txtTotalPaid.ReadOnly = False
            txtTotalPaid.Enabled = True
        End If
    End Sub

    Private Sub txtSupplierID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplierID.TextChanged

    End Sub

    Private Sub lblBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBalance.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnListUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListUpdate.Click
        Try
            If txtProductCode.Text = "" Then
                MessageBox.Show("Please retrieve product code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductCode.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(1).Value = txtProductCode.Text Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = txtProductCode.Text
                    r.Cells(2).Value = txtProductName.Text
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
                    r.Cells(3).Value = txtPricePerQty.Text
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(txtProductID.Text, txtProductCode.Text, txtProductName.Text, txtPricePerQty.Text, txtQty.Text, txtTotalAmount.Text)
            Dim j As Double = 0
            j = SubTotal()
            j = Math.Round(j, 2)
            txtSubTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
