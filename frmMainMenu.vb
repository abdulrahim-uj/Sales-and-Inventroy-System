Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.SqlServer.Management.Smo
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmMainMenu
    Dim Filename As String


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
    Sub Backup()
        Try
            Dim dt As DateTime = Today
            Dim destdir As String = "SIS_DB " & System.DateTime.Now.ToString("dd-MM-yyyy_h-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database SIS_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE SIS_DB SET Single_User WITH Rollback Immediate Restore database SIS_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE SIS_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim dt As DateTime = Today
        lblDateTime.Text = dt.ToString("dd/MM/yyyy")
        lblTime.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("winword.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.ShowDialog()
    End Sub
    Sub LogOut()
        frmPurchase.Hide()
        frmProduct.Hide()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMainMenu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub CompanyInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyInfoToolStripMenuItem.Click
        frmCompany.lblUser.Text = lblUser.Text
        frmCompany.Reset()
        frmCompany.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        frmCustomer.lblUser.Text = lblUser.Text
        frmCustomer.Reset()
        frmCustomer.ShowDialog()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub SubCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubCategoryToolStripMenuItem.Click
        frmSubCategory.lblUser.Text = lblUser.Text
        frmSubCategory.Reset()
        frmSubCategory.ShowDialog()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        frmCustomerRecord1.Reset()
        frmCustomerRecord1.ShowDialog()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub


    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        frmPurchase.lblUser.Text = lblUser.Text
        frmPurchase.lblUserType.Text = lblUserType.Text
        frmPurchase.Reset()
        frmPurchase.ShowDialog()
    End Sub

    Public Sub Getchart()
        '////////////////////////////////////////FIRST DAY AND LAST DAY OF CURRENT MONTH/////////////////////////////////////////////////////////////////////////'
        Dim FIRST_DAY As Date
        Dim LAST_DAY As Date

        con = New SqlConnection(cs)
        Try

            con.Open()
            cmd = New SqlCommand("SELECT DATEADD(MM, DATEDIFF(MM, 0, GETDATE()), 0) AS FIRST_DAY", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                FIRST_DAY = rdr.Item(0)
            End If
            rdr.Close()


            con.Open()
            cmd = New SqlCommand("SELECT DATEADD(DD, -1, DATEADD(MM, DATEDIFF(MM, 0, GETDATE()) +1, 0)) AS LAST_DAY", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                LAST_DAY = rdr.Item(0)
            End If
            rdr.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '///////////////////////////////IS THIS A WORKING CODE/////////////////////////////////////////////////////////////'

        'Try
        '    con = New SqlConnection(cs)
        '    con.Open()
        '    Dim sqlquery As String = "SELECT ProductName,QTY FROM Product,Temp_Stock WHERE Product.PID=Temp_Stock.ProductID"
        '    Dim da As New SqlDataAdapter(sqlquery, con)
        '    Dim ds As New DataSet()
        '    da.Fill(ds, "Temp_Stock")

        '    Dim newPanel As New Panel
        '    Dim newPage As New TabPage


        '    Dim ChartArea4 As ChartArea = New ChartArea()
        '    Dim Legend4 As Legend = New Legend()
        '    Dim Series4 As Series = New Series()
        '    Dim Chart4 = New Chart()
        '    Me.Controls.Add(Chart4)

        '    ChartArea4.Name = "ChartArea4"
        '    Chart4.ChartAreas.Add(ChartArea4)
        '    Legend4.Name = "Legend4"
        '    Chart4.Legends.Add(Legend4)
        '    Chart4.Location = New System.Drawing.Point(4, 99) '600, 130'
        '    Chart4.Name = "Chart4"
        '    Series4.ChartArea = "ChartArea4"
        '    Series4.Legend = "Legend4"
        '    Series4.Name = "Products"
        '    Chart4.Series.Add(Series4)
        '    Chart4.Size = New System.Drawing.Size(491, 222) '550, 250'
        '    Chart4.TabIndex = 0
        '    Chart4.Text = "Chart4"
        '    Chart4.Series("Products").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine

        '    ChartArea4.Area3DStyle.Enable3D = True
        '    'Chart4.Series("Products").XValueMember = "ProductName"
        '    Chart4.Series("Products").YValueMembers = "Qty"



        '    Chart4.DataSource = ds.Tables("Temp_Stock")


        '    '    '///////////////////////////////'



        '    '    '/////////////////////////////////////////////////////////////'

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '////////////////////////////////////////////////////BUILD PRODUCTS STOCK CHART///////////////////////////////////////////////////////////////////////////'
        'con = New SqlConnection(cs)
        'Dim commandB As SqlCommand
        'Dim dbDataSetB As New DataTable
        'Dim dtReaderB As SqlDataReader

        'Try
        '    con.Open()
        '    Dim QueryB As String
        '    Chart6.Series("Product Stock").Points.Clear()     'REFRESH the Chart'
        '    QueryB = "SELECT RTRIM(OP.OProductName) AS OPNAME,BS.Qty AS QTY FROM OurProduct OP, build_Stock BS WHERE OP.OPID = BS.OurProductID"
        '    commandB = New SqlCommand(QueryB, con)
        '    dtReaderB = commandB.ExecuteReader
        '    If dtReaderB.HasRows = False Then
        '        Stockchartnotelabel.Visible = True
        '        Stockchartnotelabel.Text = "There is no Products in your Stock Area!"
        '    End If

        '    While dtReaderB.Read

        '        Chart6.Series("Product Stock").Points.AddXY(dtReaderB.Item(0).ToString(), dtReaderB.Item(1))

        '    End While
        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '////////////////////////////////////////////////////PROFIT CHART////////////////////////////////////////////////////////////////////////////////'
        'con = New SqlConnection(cs)
        'Dim con3 As New SqlConnection
        'con3 = New SqlConnection(cs)
        'Dim command5, command6 As SqlCommand
        'Dim dbDataSet5, dbDataSet6 As New DataTable
        'Dim dtReader5, dtReader6 As SqlDataReader

        'Try
        '    con.Open()
        '    con3.Open()
        '    Dim Query5 As String
        '    Dim Query6 As String
        '    Chart5.Series("Profit").Points.Clear()     'REFRESH the Chart'
        '    Query5 = "SELECT INCOME_DATEOFMONTH, INCOME FROM VW_INCOME"
        '    Query6 = "SELECT PURCHASE_EXPENCE, DATE_OF_MONTH FROM VW_EXPENCE"
        '    command5 = New SqlCommand(Query5, con)
        '    command6 = New SqlCommand(Query6, con3)
        '    dtReader5 = command5.ExecuteReader
        '    dtReader6 = command6.ExecuteReader
        '    If dtReader5.HasRows = False Then
        '        Chart5.Series("Profit").IsVisibleInLegend = False
        '    End If

        '    While dtReader5.Read
        '        Dim sss As Double
        '        Dim xxx As Double
        '        Dim yyy As Double
        '        While dtReader6.Read
        '            xxx = dtReader6.Item(0)
        '            sss = dtReader5.Item(1)
        '            yyy = sss - xxx
        '        End While

        '        Chart5.Series("Profit").Points.AddXY(dtReader5.Item(0), yyy)

        '    End While
        '    con.Close()
        '    con3.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '///////////////////////////////////////////////////PURCHASE and SALES CHART/////////////////////////////////////////////////////////////////////'
        'con = New SqlConnection(cs)
        'Dim con1 As New SqlConnection
        'con1 = New SqlConnection(cs)
        'Dim command3, command4 As SqlCommand
        'Dim dbDataSet3, dbDataSet4 As New DataTable
        'Dim dtReader3, dtReader4 As SqlDataReader

        'Try
        '    con.Open()
        '    con1.Open()
        '    Dim Query3, Query4 As String
        '    Chart4.Series("Purchase").Points.Clear()     'REFRESH the Chart'
        '    Chart4.Series("Sales").Points.Clear()     'REFRESH the Chart'
        '    Query3 = "SELECT P.CostPrice,SUM( S.Qty ) AS QUANTITY, P.CostPrice * SUM(S.Qty) AS EXPENCE FROM Product P, Stock_Product S WHERE P.PID = S.ProductID GROUP BY P.CostPrice, P.PID"
        '    Query4 = "SELECT I.InvoiceID, SUM(I.TotalPaid) AS INCOME FROM Invoice_Payment I GROUP BY I.InvoiceID"
        '    command3 = New SqlCommand(Query3, con)
        '    command4 = New SqlCommand(Query4, con1)
        '    dtReader3 = command3.ExecuteReader
        '    dtReader4 = command4.ExecuteReader
        '    If dtReader3.HasRows = False Then
        '        Expencechartnotelabel.Visible = True
        '        Expencechartnotelabel.Text = "There is no Activities in this Area!"
        '    End If
        '    If dtReader4.HasRows = False Then
        '        Expencechartnotelabel.Visible = True
        '        Expencechartnotelabel.Text = "There is no Activities in this Area!"
        '    End If
        '    While dtReader3.Read

        '        Chart4.Series("Purchase").Points.AddY(dtReader3.Item(2))
        '        'Chart4.Series("Expence").Points.AddXY(dtReader.Item(0).ToString(), dtReader.Item(1))

        '    End While
        '    con.Close()
        '    While dtReader4.Read
        '        Chart4.Series("Sales").Points.AddY(dtReader4.Item(1))
        '    End While
        '    con1.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\RAW STOCK CHART\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\'
        'con = New SqlConnection(cs)
        'Dim command As SqlCommand
        'Dim dbDataSet As New DataTable
        'Dim dtReader As SqlDataReader

        'Try
        '    con.Open()
        '    Dim Query As String
        '    Chart1.Series("Raw Stock").Points.Clear()     'REFRESH the Chart'
        '    Query = "SELECT RTRIM(product.ProductName) AS chpname,temp_stock.Qty AS quantity FROM Product,Temp_Stock WHERE Product.PID=Temp_Stock.ProductID"
        '    command = New SqlCommand(Query, con)
        '    dtReader = command.ExecuteReader
        '    If dtReader.HasRows = False Then
        '        Stockchartnotelabel.Visible = True
        '        Stockchartnotelabel.Text = "There is no Products in your Stock Area!"
        '    End If

        '    While dtReader.Read

        '        Chart1.Series("Raw Stock").Points.AddXY(dtReader.Item(0).ToString(), dtReader.Item(1))

        '    End While
        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        '//////////////////////////////////////////////////////////RAW PURCHASE CHART////////////////////////////////////////////////////////////////////////////////'
        'con = New SqlConnection(cs)
        'Dim command1 As SqlCommand
        'Dim dbDataSet1 As New DataTable
        'Dim dtReader1 As SqlDataReader

        'Try
        '    con.Open()
        '    Dim Query1 As String
        '    Chart2.Series("Raw Purchase").Points.Clear()    'REFRESH the Chart'
        '    Query1 = "SELECT SUM(SubTotal) AS TOTAL,Product.PID,Product.ProductName FROM Stock, Product, Stock_Product WHERE Stock.ST_ID = Stock_Product.StockID AND Product.PID = Stock_Product.ProductID AND Stock.Date BETWEEN '" & FIRST_DAY & "' AND '" & LAST_DAY & "' GROUP BY Product.PID, Product.ProductName"
        '    command1 = New SqlCommand(Query1, con)
        '    ''cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = FIRST_DAY
        '    'cmd.Parameters.Add("@d1", SqlDbType.Date, 30, "Date").Value = FIRST_DAY
        '    'cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = LAST_DAY
        '    'cmd.Connection = con
        '    dtReader1 = command1.ExecuteReader
        '    If dtReader1.HasRows = False Then
        '        purchasechartnotelabel.Visible = True
        '        purchasechartnotelabel.Text = "There is no Purchase Orders in this Month!"
        '    End If
        '    While dtReader1.Read

        '        Chart2.Series("Raw Purchase").Points.AddXY(dtReader1.Item(2).ToString(), dtReader1.Item(0))

        '    End While
        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        '/////////////////////////////////////////////////////////////RAW SALES CHART//////////////////////////////////////////////////////////////////////////////'
        'con = New SqlConnection(cs)
        'Dim command2 As SqlCommand
        'Dim dbDataSet2 As New DataTable
        'Dim dtReader2 As SqlDataReader

        'Try
        '    con.Open()
        '    Dim Query2 As String
        '    Chart3.Series("Raw Sales").Points.Clear()    'REFRESH the Chart'
        '    Query2 = "SELECT SUM(II.GrandTotal) AS TOTAL,P.ProductName,IP.ProductID FROM InvoiceInfo II, Invoice_Product IP, Invoice_Payment IY, Product P WHERE II.Inv_ID = IP.InvoiceID AND II.Inv_ID = IY.InvoiceID AND IP.ProductID = P.PID AND II.InvoiceDate BETWEEN '" & FIRST_DAY & "' AND '" & LAST_DAY & "' GROUP BY IP.ProductID, P.ProductName"
        '    command2 = New SqlCommand(Query2, con)
        '    dtReader2 = command2.ExecuteReader
        '    If dtReader2.HasRows = False Then
        '        Saleschartnotelabel.Visible = True
        '        Saleschartnotelabel.Text = "There is no Sales Orders in this Month!"
        '    End If
        '    While dtReader2.Read

        '        Chart3.Series("Raw Sales").Points.AddXY(dtReader2.Item(1).ToString(), dtReader2.Item(0))

        '    End While
        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PID,RTRIM(Product.ProductCode),RTRIM(ProductName),CostPrice,SellingPrice,Discount,VAT,Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Qty >= 0 order by PID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(1).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    Dim i As Integer
                    Dim j As Integer
                    i = rdr(0)
                    j = i + 1
                    If r.Cells(7).Value <= j Then
                        r.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    If r.Cells(7).Value < i Then
                        r.DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT OP.OPID, RTRIM(OP.OProductCode), RTRIM(OP.OProductName),OP.CostPrice,OP.SellingPrice,OP.Discount, OP.VAT,BS.Qty FROM build_Stock BS, OurProduct OP WHERE OP.OPID = BS.OurProductID AND BS.Qty >=0 ORDER BY OP.OPID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
            DataGridView2.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtProductName.Text = ""
        Getdata()

    End Sub
    Private Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorySoft2", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\InventorySoft2", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 7 Then
            Return False
        End If
        Return True
    End Function
    Private Sub frmMainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SIS_DBDataSet2.Chart_Values' table. You can move, or remove it, as needed.

        'Dim result As Boolean = HandleRegistry()
        'If result = False Then 'something went wrong
        'MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software call us at +919827858191", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End
        'End If
        If lblUserType.Text = "Admin" Then
            MasterEntryToolStripMenuItem.Enabled = True
            RegistrationToolStripMenuItem.Enabled = True
            LogsToolStripMenuItem.Enabled = True
            DatabaseToolStripMenuItem.Enabled = True
            CustomerToolStripMenuItem.Enabled = True
            SupplierToolStripMenuItem.Enabled = True
            ProductToolStripMenuItem.Enabled = True
            StockToolStripMenuItem.Enabled = True
            ServiceToolStripMenuItem.Enabled = True
            StockInToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = True
            QuotationToolStripMenuItem.Enabled = True
            RecordToolStripMenuItem.Enabled = True
            ReportsToolStripMenuItem.Enabled = True
            VoucherToolStripMenuItem.Enabled = True
            SalesmanToolStripMenuItem3.Enabled = True
            SendSMSToolStripMenuItem.Enabled = True
        End If
        If lblUserType.Text = "Sales Person" Then
            MasterEntryToolStripMenuItem.Enabled = False
            RegistrationToolStripMenuItem.Enabled = False
            LogsToolStripMenuItem.Enabled = False
            DatabaseToolStripMenuItem.Enabled = False
            CustomerToolStripMenuItem.Enabled = True
            SupplierToolStripMenuItem.Enabled = False
            ProductToolStripMenuItem.Enabled = False
            StockToolStripMenuItem.Enabled = False
            ServiceToolStripMenuItem.Enabled = True
            StockInToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = True
            QuotationToolStripMenuItem.Enabled = True
            RecordToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            VoucherToolStripMenuItem.Enabled = False
            SalesmanToolStripMenuItem3.Enabled = False
            SendSMSToolStripMenuItem.Enabled = False
        End If
        If lblUserType.Text = "Inventory Manager" Then
            MasterEntryToolStripMenuItem.Enabled = False
            RegistrationToolStripMenuItem.Enabled = False
            LogsToolStripMenuItem.Enabled = False
            DatabaseToolStripMenuItem.Enabled = False
            CustomerToolStripMenuItem.Enabled = False
            SupplierToolStripMenuItem.Enabled = False
            ProductToolStripMenuItem.Enabled = True
            StockToolStripMenuItem.Enabled = True
            ServiceToolStripMenuItem.Enabled = False
            StockInToolStripMenuItem.Enabled = True
            BillingToolStripMenuItem.Enabled = False
            QuotationToolStripMenuItem.Enabled = False
            RecordToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            VoucherToolStripMenuItem.Enabled = False
            SalesmanToolStripMenuItem3.Enabled = False
            SendSMSToolStripMenuItem.Enabled = False
        End If
        Getdata()
        Getchart()
        DataGridView1.ClearSelection()
        DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub StockInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInToolStripMenuItem.Click
        'frmCurrentStock.Reset()
        'frmCurrentStock.ShowDialog()
        frmBuildProducts.lblUser.Text = lblUser.Text
        frmBuildProducts.lblUserType.Text = lblUserType.Text
        frmBuildProducts.Reset()
        frmBuildProducts.ShowDialog()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(DataGridView1)
        ExportExcel(DataGridView2)
    End Sub

    Private Sub txtProductName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PID,RTRIM(Product.ProductCode),RTRIM(ProductName),CostPrice,SellingPrice,Discount,VAT,Qty from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and qty >= 0 and ProductName like '%" & txtProductName.Text & "%' order by PID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ReorderPoint from Product where ProductCode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", r.Cells(1).Value.ToString())
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    Dim i As Integer
                    Dim j As Integer
                    i = rdr(0)
                    j = i + 1
                    If r.Cells(7).Value <= j Then
                        r.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    If r.Cells(7).Value < i Then
                        r.DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub ContactsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactsToolStripMenuItem.Click
        frmContacts.lblUser.Text = lblUser.Text
        frmContacts.Reset()
        frmContacts.ShowDialog()
    End Sub

    Private Sub IndividualToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        'frmProduct.lblUser.Text = lblUser.Text
        'frmProduct.lblUserType.Text = lblUserType.Text
        'frmProduct.Reset()
        'frmProduct.ShowDialog()
    End Sub

    Private Sub ProductToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductToolStripMenuItem2.Click
        frmProductRecord.Reset()
        frmProductRecord.ShowDialog()
    End Sub

    Private Sub ServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceToolStripMenuItem.Click
        frmServices.lblUser.Text = lblUser.Text
        frmServices.lblUserType.Text = lblUserType.Text
        frmServices.Reset()
        frmServices.ShowDialog()
    End Sub

    Private Sub ServiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceToolStripMenuItem1.Click
        frmServicesRecord.Reset()
        frmServicesRecord.ShowDialog()
    End Sub

    Private Sub QuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem.Click
        frmQuotation.lblUser.Text = lblUser.Text
        frmQuotation.lblUserType.Text = lblUserType.Text
        frmQuotation.Reset()
        frmQuotation.ShowDialog()
    End Sub

    Private Sub QuotationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem1.Click
        frmQuotationRecord1.Reset()
        frmQuotationRecord1.ShowDialog()
    End Sub

    Private Sub BillingProductsServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingProductsServiceToolStripMenuItem.Click
        frmBillingRecord1.lblSet.Text = "Report need"
        frmBillingRecord1.Reset()
        frmBillingRecord1.ShowDialog()
    End Sub


    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        frmSalesReport.Reset()
        frmSalesReport.ShowDialog()
    End Sub

    Private Sub ServiceBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceBillingToolStripMenuItem.Click
        frmServiceDoneReport.Reset()
        frmServiceDoneReport.ShowDialog()
    End Sub

    Private Sub StockInAndStockOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInAndStockOutToolStripMenuItem.Click
        frmStockInAndOutReport.ShowDialog()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click
        frmPurchaseReport.Reset()
        frmPurchaseReport.ShowDialog()
    End Sub

    Private Sub ProfitAndLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitAndLossToolStripMenuItem.Click
        frmProfitAndLossReport.Reset()
        frmProfitAndLossReport.ShowDialog()
    End Sub

    Private Sub VoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherToolStripMenuItem.Click
        frmVoucher.Reset()
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.ShowDialog()
    End Sub

    Private Sub ExpenditureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenditureToolStripMenuItem.Click
        frmVoucherReport.Reset()
        frmVoucherReport.ShowDialog()
    End Sub

    Private Sub CreditorsAndDebtorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditorsAndDebtorsToolStripMenuItem.Click
        frmCreditorsAndDebtorsReport.ShowDialog()
    End Sub

    Private Sub OverallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverallToolStripMenuItem.Click
        frmOverallReport.Reset()
        frmOverallReport.ShowDialog()
    End Sub

    Private Sub SQLServerSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SQLServerSettingToolStripMenuItem.Click
        frmSqlServerSetting.Reset()
        frmSqlServerSetting.lblSet.Text = "Main Form"
        frmSqlServerSetting.ShowDialog()
    End Sub

    Private Sub PurchaseDaybookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseDaybookToolStripMenuItem.Click
        frmPurchaseDaybook.Reset()
        frmPurchaseDaybook.ShowDialog()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub GeneralDaybookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralDaybookToolStripMenuItem.Click
        frmGeneralDayBook.Reset()
        frmGeneralDayBook.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub PaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentsToolStripMenuItem.Click
        frmPaymentRecord.Reset()
        frmPaymentRecord.ShowDialog()
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        frmTrialBalance.Reset()
        frmTrialBalance.ShowDialog()
    End Sub

    Private Sub SupplierLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierLedgerToolStripMenuItem.Click
        frmSupplierLedger.Reset()
        frmSupplierLedger.ShowDialog()
    End Sub

    Private Sub CustomerLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerLedgerToolStripMenuItem.Click
        frmCustomerLedger.Reset()
        frmCustomerLedger.ShowDialog()
    End Sub


    Private Sub SalesmanToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSalesmanRecord.Reset()
        frmSalesman.ShowDialog()
    End Sub

    Private Sub SalesmanToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesmanToolStripMenuItem3.Click
        frmSalesman.Reset()
        frmSalesman.lblUser.Text = lblUser.Text
        frmSalesman.ShowDialog()
    End Sub

    Private Sub SalesmanLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesmanLedgerToolStripMenuItem.Click
        frmSalesmanLedger.Reset()
        frmSalesmanLedger.ShowDialog()
    End Sub

    Private Sub SalesmanCommissionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesmanCommissionToolStripMenuItem.Click
        frmSalesmanCommmissionReport.Reset()
        frmSalesmanCommmissionReport.ShowDialog()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        frmTaxReport.Reset()
        frmTaxReport.ShowDialog()
    End Sub

    Private Sub SendSMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendSMSToolStripMenuItem.Click
        frmSendSMS.lblUser.Text = lblUser.Text
        frmSendSMS.Reset()
        frmSendSMS.ShowDialog()
    End Sub

    Private Sub CreditTermsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditTermsToolStripMenuItem.Click
        frmCreditTermsReport.Reset()
        frmCreditTermsReport.ShowDialog()
    End Sub

    Private Sub CreditTermsStatementsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditTermsStatementsToolStripMenuItem.Click
        frmCreditTermsStatementsReport.Reset()
        frmCreditTermsStatementsReport.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsToolStripMenuItem.Click
        'frmSales.lblUser.Text = lblUser.Text
        'frmSales.lblUserType.Text = lblUserType.Text
        'frmSales.Reset()
        'frmSales.ShowDialog()

        
    End Sub

    Private Sub ProductsRepairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsRepairToolStripMenuItem.Click
        frmBilling1.lblUser.Text = lblUser.Text
        frmBilling1.lblUserType.Text = lblUserType.Text
        frmBilling1.Reset()
        frmBilling1.ShowDialog()
    End Sub

    Private Sub SalesmanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesmanToolStripMenuItem1.Click
        frmSalesmanRecord.lblSet.Text = "Report need"
        frmSalesmanRecord.Reset()
        frmSalesmanRecord.ShowDialog()
    End Sub

    Private Sub RestoreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem1.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE SIS_DB SET Single_User WITH Rollback Immediate Restore database SIS_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE SIS_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem1.Click
        Backup()
    End Sub

    Private Sub LOAD_CHART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Getchart()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart1.Click
        Getchart()
    End Sub

    Private Sub Chart2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart2.Click
        Getchart()
    End Sub

    Private Sub Chart3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart3.Click
        Getchart()
    End Sub

    Private Sub RawMaterailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawMaterailsToolStripMenuItem.Click
        frmProduct.lblUser.Text = lblUser.Text
        frmProduct.lblUserType.Text = lblUserType.Text
        frmProduct.Reset()
        frmProduct.ShowDialog()
    End Sub

    Private Sub OurCreationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OurCreationToolStripMenuItem.Click
        frmOurCreation.lblUser.Text = lblUser.Text
        frmOurCreation.lblUserType.Text = lblUserType.Text
        frmOurCreation.Reset()
        frmOurCreation.ShowDialog()
    End Sub

    Private Sub RawMaterialsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawMaterialsToolStripMenuItem.Click
        frmBilling.lblUser.Text = lblUser.Text
        frmBilling.lblUserType.Text = lblUserType.Text
        frmBilling.Reset()
        frmBilling.ShowDialog()
    End Sub

    Private Sub ManufacturedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManufacturedToolStripMenuItem.Click
        frmBPBilling.lblUser.Text = lblUser.Text
        frmBPBilling.lblUserType.Text = lblUserType.Text
        frmBPBilling.Reset()
        frmBPBilling.ShowDialog()
    End Sub
End Class