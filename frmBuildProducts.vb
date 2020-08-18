Imports System.Data.SqlClient
Imports System.IO
Public Class frmBuildProducts
    Sub Reset()
        dtpDate.Text = Today()
        txtProductID.Text = ""
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtPricePerQty.Text = ""
        txtQty.Text = ""
        txtTotalAmount.Text = ""
        txtRawPid.Text = ""
        txtRawQty.Text = ""
        txtTotalRawQty.Text = ""
        txtRemarks.Text = ""
        dgwRawstk1.Rows.Clear()
        txtPricePerQty.ReadOnly = True

        btnSave.Enabled = True
        btnDelete.Enabled = False

        btnAdd.Enabled = True
        pnlCalc.Enabled = True




        auto()
    End Sub
    Sub auto()
        Try
            txtBuildId.Text = GenerateID()
            txtBuildNo.Text = "BL-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 BUILDID FROM BuildProductInfo ORDER BY BUILDID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("BUILDID")
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmBuildProductRecord.lblSet.Text = "OurProductStockAdd"
        frmBuildProductRecord.Reset()
        frmBuildProductRecord.ShowDialog()
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        Dim i As Double = 0
        Dim TableQty As Integer
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
        Dim opQty As Integer = 0
        opQty = Val(txtQty.Text)
        '+++++++++++++++++++++++++++++++++++++++++++++++++++'
        For Each row As DataGridViewRow In dgwRawstk1.Rows
            If Not row.IsNewRow Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1"
                cmd = New SqlCommand(ctx)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    '------------------------------------------'
                    txtRawQty.Text = row.Cells(3).Value

                    Dim y As Double = 0
                    y = CDbl(Val(txtRawQty.Text) * Val(txtQty.Text))
                    y = Math.Round(y, 2)
                    row.Cells(5).Value = y
                    txtTotalRawQty.Text = y
                    '----------------------------------------------------------'
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "SELECT Qty FROM Temp_Stock where ProductID=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                    rdr = cmd.ExecuteReader()
                    If rdr.HasRows Then
                        rdr.Read()
                        TableQty = rdr.Item("Qty")
                        If opQty > TableQty Then
                            MessageBox.Show("Sorry you have no raw materials to build this Product! ", "Stock Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            SetNull()
                        End If
                    End If
                    rdr.Close()
                End If
            End If
        Next
    End Sub
    Private Sub SetNull()
        'TableQty = ""
        'opQty = ""
        txtQty.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtProductName.Text)) = 0 Then
            MessageBox.Show("Please enter Product Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtQty.Text)) = 0 Then
            MessageBox.Show("Please enter Quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "INSERT INTO BuildProductInfo (BUILDID,BuildNo,BuildDate,OurProductId,PricePerUnit,BuildQty,TotalAmount,Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", txtBuildId.Text)
            cmd.Parameters.AddWithValue("@d2", txtBuildNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", txtProductID.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtPricePerQty.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtQty.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtTotalAmount.Text))
            cmd.Parameters.AddWithValue("@d8", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            For Each row As DataGridViewRow In dgwRawstk1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1"
                    cmd = New SqlCommand(ctx)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty = Qty - " & row.Cells(5).Value & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbupdate As String = "UPDATE build_Stock SET Qty = Qty + " & Val(txtQty.Text) & " WHERE OurProductID = @d1"
            cmd = New SqlCommand(cbupdate)
            cmd.Parameters.AddWithValue("@d1", txtProductID.Text)
            'cmd.Parameters.AddWithValue("@d2", Val(txtQty.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            LogFunc(lblUser.Text, "added the new Build Product into Stock '" & txtBuildNo.Text & "' having Product code '" & txtProductCode.Text & "'")
            RefreshRecords()
            MessageBox.Show("Successfully saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            auto()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Its already Builded and data stored in multiple lows, Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
                RefreshRecords()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            For Each row As DataGridViewRow In dgwRawstk1.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctx As String = "select ProductID from Temp_Stock where ProductID=@d1"
                    cmd = New SqlCommand(ctx)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty = Qty + " & row.Cells(5).Value & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbupdate As String = "UPDATE build_Stock SET Qty = Qty - " & Val(txtQty.Text) & " WHERE OurProductID = @d1"
            cmd = New SqlCommand(cbupdate)
            cmd.Parameters.AddWithValue("@d1", txtProductID.Text)
            'cmd.Parameters.AddWithValue("@d2", Val(txtQty.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from BuildProductInfo where BUILDID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtBuildId.Text)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LogFunc(lblUser.Text, "deleted the Build Product '" & txtProductName.Text & "' having Build Product code '" & txtProductCode.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
            Reset()
            auto()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Dim frm As New frmBuildProductRecord
        frm.lblSet.Text = "Build Product GetData"
        frm.Reset()
        frm.ShowDialog()
    End Sub
End Class