<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuildProducts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgwRawstk1 = New System.Windows.Forms.DataGridView()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBuildId = New System.Windows.Forms.TextBox()
        Me.txtTotalRawQty = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.btnListUpdate = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.txtPricePerQty = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRawQty = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuildNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRawPid = New System.Windows.Forms.TextBox()
        Me.txtOpeningStock = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtfeatures = New System.Windows.Forms.TextBox()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnImageRemove = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlCalc = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtVat = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSellingPrice = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCostOfPrice = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtElectricityCharges = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtLabourCharges = New System.Windows.Forms.TextBox()
        Me.txtOtherCharges = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtDiscPer = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgwRawstk1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCalc.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgwRawstk1)
        Me.Panel1.Controls.Add(Me.txtBuildId)
        Me.Panel1.Controls.Add(Me.txtTotalRawQty)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtRawQty)
        Me.Panel1.Controls.Add(Me.txtRemarks)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtRawPid)
        Me.Panel1.Controls.Add(Me.txtOpeningStock)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtfeatures)
        Me.Panel1.Controls.Add(Me.btnGetData)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.btnImageRemove)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.pnlCalc)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(879, 500)
        Me.Panel1.TabIndex = 0
        '
        'dgwRawstk1
        '
        Me.dgwRawstk1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwRawstk1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column1})
        Me.dgwRawstk1.Location = New System.Drawing.Point(495, 168)
        Me.dgwRawstk1.Name = "dgwRawstk1"
        Me.dgwRawstk1.Size = New System.Drawing.Size(222, 106)
        Me.dgwRawstk1.TabIndex = 350
        Me.dgwRawstk1.Visible = False
        '
        'Column15
        '
        Me.Column15.HeaderText = "OurProductid"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "RawProductid"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "RawPrice"
        Me.Column17.Name = "Column17"
        '
        'Column18
        '
        Me.Column18.HeaderText = "RawQty"
        Me.Column18.Name = "Column18"
        '
        'Column19
        '
        Me.Column19.HeaderText = "RawAmount"
        Me.Column19.Name = "Column19"
        '
        'Column1
        '
        Me.Column1.HeaderText = "TotalRowQty"
        Me.Column1.Name = "Column1"
        '
        'txtBuildId
        '
        Me.txtBuildId.Location = New System.Drawing.Point(254, 95)
        Me.txtBuildId.Name = "txtBuildId"
        Me.txtBuildId.Size = New System.Drawing.Size(35, 20)
        Me.txtBuildId.TabIndex = 335
        Me.txtBuildId.Visible = False
        '
        'txtTotalRawQty
        '
        Me.txtTotalRawQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalRawQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRawQty.Location = New System.Drawing.Point(685, 365)
        Me.txtTotalRawQty.Name = "txtTotalRawQty"
        Me.txtTotalRawQty.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalRawQty.TabIndex = 333
        Me.txtTotalRawQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalRawQty.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtProductID)
        Me.GroupBox2.Controls.Add(Me.btnListUpdate)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox2.Controls.Add(Me.txtPricePerQty)
        Me.GroupBox2.Controls.Add(Me.txtQty)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtProductName)
        Me.GroupBox2.Controls.Add(Me.txtProductCode)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(519, 162)
        Me.GroupBox2.TabIndex = 349
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Product Info"
        '
        'txtProductID
        '
        Me.txtProductID.Location = New System.Drawing.Point(384, 50)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(35, 20)
        Me.txtProductID.TabIndex = 313
        Me.txtProductID.Visible = False
        '
        'btnListUpdate
        '
        Me.btnListUpdate.Enabled = False
        Me.btnListUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnListUpdate.Location = New System.Drawing.Point(384, 23)
        Me.btnListUpdate.Name = "btnListUpdate"
        Me.btnListUpdate.Size = New System.Drawing.Size(90, 21)
        Me.btnListUpdate.TabIndex = 328
        Me.btnListUpdate.Text = "Update"
        Me.btnListUpdate.UseVisualStyleBackColor = True
        Me.btnListUpdate.Visible = False
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Location = New System.Drawing.Point(310, 23)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(68, 21)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        Me.btnRemove.Visible = False
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(129, 131)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(70, 21)
        Me.txtTotalAmount.TabIndex = 7
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPricePerQty
        '
        Me.txtPricePerQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPricePerQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPricePerQty.Location = New System.Drawing.Point(129, 77)
        Me.txtPricePerQty.Name = "txtPricePerQty"
        Me.txtPricePerQty.Size = New System.Drawing.Size(70, 21)
        Me.txtPricePerQty.TabIndex = 5
        Me.txtPricePerQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(129, 104)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 21)
        Me.txtQty.TabIndex = 1
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Total Amount :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Price Per Unit :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Quantity :"
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Location = New System.Drawing.Point(250, 23)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(54, 21)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(205, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 21)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtProductName
        '
        Me.txtProductName.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(129, 50)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(249, 21)
        Me.txtProductName.TabIndex = 4
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.Location = New System.Drawing.Point(129, 24)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.Size = New System.Drawing.Size(70, 21)
        Me.txtProductCode.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Product Code :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Product Name :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(587, 365)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 334
        Me.Label19.Text = "Total Raw Qty:"
        Me.Label19.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 334)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 348
        Me.Label4.Text = "Remarks :"
        '
        'txtRawQty
        '
        Me.txtRawQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtRawQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawQty.Location = New System.Drawing.Point(685, 336)
        Me.txtRawQty.Name = "txtRawQty"
        Me.txtRawQty.Size = New System.Drawing.Size(70, 21)
        Me.txtRawQty.TabIndex = 331
        Me.txtRawQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRawQty.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(6, 350)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(519, 145)
        Me.txtRemarks.TabIndex = 11
        Me.txtRemarks.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(585, 336)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 332
        Me.Label17.Text = "RawQty :"
        Me.Label17.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBuildNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 90)
        Me.GroupBox1.TabIndex = 346
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Build Info"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(109, 52)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(124, 20)
        Me.dtpDate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Build No. :"
        '
        'txtBuildNo
        '
        Me.txtBuildNo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtBuildNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuildNo.Location = New System.Drawing.Point(109, 26)
        Me.txtBuildNo.Name = "txtBuildNo"
        Me.txtBuildNo.Size = New System.Drawing.Size(124, 21)
        Me.txtBuildNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Build Date :"
        '
        'txtRawPid
        '
        Me.txtRawPid.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtRawPid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRawPid.Location = New System.Drawing.Point(685, 307)
        Me.txtRawPid.Name = "txtRawPid"
        Me.txtRawPid.Size = New System.Drawing.Size(70, 21)
        Me.txtRawPid.TabIndex = 329
        Me.txtRawPid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRawPid.Visible = False
        '
        'txtOpeningStock
        '
        Me.txtOpeningStock.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtOpeningStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpeningStock.Location = New System.Drawing.Point(603, 651)
        Me.txtOpeningStock.Name = "txtOpeningStock"
        Me.txtOpeningStock.Size = New System.Drawing.Size(70, 21)
        Me.txtOpeningStock.TabIndex = 330
        Me.txtOpeningStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOpeningStock.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(587, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 330
        Me.Label10.Text = "RAWid :"
        Me.Label10.Visible = False
        '
        'txtfeatures
        '
        Me.txtfeatures.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtfeatures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfeatures.Location = New System.Drawing.Point(603, 615)
        Me.txtfeatures.Name = "txtfeatures"
        Me.txtfeatures.Size = New System.Drawing.Size(257, 21)
        Me.txtfeatures.TabIndex = 345
        Me.txtfeatures.Visible = False
        '
        'btnGetData
        '
        Me.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGetData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.Location = New System.Drawing.Point(745, 223)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(82, 28)
        Me.btnGetData.TabIndex = 344
        Me.btnGetData.Text = "&GetData"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(745, 119)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(82, 28)
        Me.btnNew.TabIndex = 342
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnImageRemove
        '
        Me.btnImageRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImageRemove.Location = New System.Drawing.Point(836, 550)
        Me.btnImageRemove.Name = "btnImageRemove"
        Me.btnImageRemove.Size = New System.Drawing.Size(76, 28)
        Me.btnImageRemove.TabIndex = 340
        Me.btnImageRemove.Text = "&Remove"
        Me.btnImageRemove.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(745, 188)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(82, 28)
        Me.btnDelete.TabIndex = 334
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(745, 153)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 28)
        Me.btnSave.TabIndex = 333
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlCalc
        '
        Me.pnlCalc.BackColor = System.Drawing.Color.Transparent
        Me.pnlCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCalc.Controls.Add(Me.Label16)
        Me.pnlCalc.Controls.Add(Me.Label15)
        Me.pnlCalc.Controls.Add(Me.txtVat)
        Me.pnlCalc.Controls.Add(Me.Label14)
        Me.pnlCalc.Controls.Add(Me.txtSellingPrice)
        Me.pnlCalc.Controls.Add(Me.Label13)
        Me.pnlCalc.Controls.Add(Me.Label12)
        Me.pnlCalc.Controls.Add(Me.txtCostOfPrice)
        Me.pnlCalc.Controls.Add(Me.Label11)
        Me.pnlCalc.Controls.Add(Me.txtElectricityCharges)
        Me.pnlCalc.Controls.Add(Me.txtSubTotal)
        Me.pnlCalc.Controls.Add(Me.txtLabourCharges)
        Me.pnlCalc.Controls.Add(Me.txtOtherCharges)
        Me.pnlCalc.Controls.Add(Me.Label31)
        Me.pnlCalc.Controls.Add(Me.Label45)
        Me.pnlCalc.Controls.Add(Me.Label46)
        Me.pnlCalc.Controls.Add(Me.txtDiscPer)
        Me.pnlCalc.Controls.Add(Me.Label18)
        Me.pnlCalc.Location = New System.Drawing.Point(9, 587)
        Me.pnlCalc.Name = "pnlCalc"
        Me.pnlCalc.Size = New System.Drawing.Size(579, 140)
        Me.pnlCalc.TabIndex = 332
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(166, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 16)
        Me.Label16.TabIndex = 339
        Me.Label16.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 338
        Me.Label15.Text = "VAT :"
        '
        'txtVat
        '
        Me.txtVat.Location = New System.Drawing.Point(101, 59)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.Size = New System.Drawing.Size(62, 20)
        Me.txtVat.TabIndex = 337
        Me.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 336
        Me.Label14.Text = "Selling Price :"
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.Location = New System.Drawing.Point(101, 113)
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.Size = New System.Drawing.Size(88, 20)
        Me.txtSellingPrice.TabIndex = 335
        Me.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 334
        Me.Label13.Text = "Total Cost :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(195, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 13)
        Me.Label12.TabIndex = 333
        Me.Label12.Text = "Electricity Charges :"
        '
        'txtCostOfPrice
        '
        Me.txtCostOfPrice.BackColor = System.Drawing.SystemColors.Control
        Me.txtCostOfPrice.Location = New System.Drawing.Point(101, 87)
        Me.txtCostOfPrice.Name = "txtCostOfPrice"
        Me.txtCostOfPrice.ReadOnly = True
        Me.txtCostOfPrice.Size = New System.Drawing.Size(88, 20)
        Me.txtCostOfPrice.TabIndex = 331
        Me.txtCostOfPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 332
        Me.Label11.Text = "Labour Charges :"
        '
        'txtElectricityCharges
        '
        Me.txtElectricityCharges.Location = New System.Drawing.Point(295, 33)
        Me.txtElectricityCharges.Name = "txtElectricityCharges"
        Me.txtElectricityCharges.Size = New System.Drawing.Size(88, 20)
        Me.txtElectricityCharges.TabIndex = 329
        Me.txtElectricityCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(101, 7)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(88, 20)
        Me.txtSubTotal.TabIndex = 330
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLabourCharges
        '
        Me.txtLabourCharges.Location = New System.Drawing.Point(101, 32)
        Me.txtLabourCharges.Name = "txtLabourCharges"
        Me.txtLabourCharges.Size = New System.Drawing.Size(88, 20)
        Me.txtLabourCharges.TabIndex = 328
        Me.txtLabourCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherCharges
        '
        Me.txtOtherCharges.Location = New System.Drawing.Point(485, 32)
        Me.txtOtherCharges.Name = "txtOtherCharges"
        Me.txtOtherCharges.Size = New System.Drawing.Size(88, 20)
        Me.txtOtherCharges.TabIndex = 330
        Me.txtOtherCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(59, 13)
        Me.Label31.TabIndex = 331
        Me.Label31.Text = "Sub Total :"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(359, 61)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(20, 16)
        Me.Label45.TabIndex = 330
        Me.Label45.Text = "%"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(195, 63)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(55, 13)
        Me.Label46.TabIndex = 329
        Me.Label46.Text = "Discount :"
        '
        'txtDiscPer
        '
        Me.txtDiscPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscPer.Location = New System.Drawing.Point(294, 59)
        Me.txtDiscPer.Name = "txtDiscPer"
        Me.txtDiscPer.Size = New System.Drawing.Size(62, 20)
        Me.txtDiscPer.TabIndex = 0
        Me.txtDiscPer.Text = "0.00"
        Me.txtDiscPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(389, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "Other Charges :"
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(745, 257)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 28)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblUserType)
        Me.Panel2.Controls.Add(Me.lblUser)
        Me.Panel2.Controls.Add(Me.lblSet)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(870, 62)
        Me.Panel2.TabIndex = 0
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Location = New System.Drawing.Point(136, 25)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(56, 13)
        Me.lblUserType.TabIndex = 0
        Me.lblUserType.Text = "User Type"
        Me.lblUserType.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(136, 38)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "User"
        Me.lblUser.Visible = False
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Location = New System.Drawing.Point(236, 25)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(23, 13)
        Me.lblSet.TabIndex = 0
        Me.lblSet.Text = "Set"
        Me.lblSet.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(322, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Our Product Stock Entry"
        '
        'frmBuildProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(890, 518)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBuildProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBuildProducts"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgwRawstk1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCalc.ResumeLayout(False)
        Me.pnlCalc.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtOpeningStock As System.Windows.Forms.TextBox
    Friend WithEvents txtfeatures As System.Windows.Forms.TextBox
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Public WithEvents btnImageRemove As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlCalc As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSellingPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCostOfPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtElectricityCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLabourCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherCharges As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtDiscPer As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBuildNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnListUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPricePerQty As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRawQty As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRawPid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalRawQty As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents txtProductID As System.Windows.Forms.TextBox
    Friend WithEvents txtBuildId As System.Windows.Forms.TextBox
    Friend WithEvents lblUserType As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents dgwRawstk1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
