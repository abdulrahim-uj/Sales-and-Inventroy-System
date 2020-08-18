<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.txtActivationID = New System.Windows.Forms.TextBox()
        Me.txtHardwareID = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxclockspeed = New System.Windows.Forms.TextBox()
        Me.txtBBVersion = New System.Windows.Forms.TextBox()
        Me.txtPcSystemtype = New System.Windows.Forms.TextBox()
        Me.txtBBManufacturer = New System.Windows.Forms.TextBox()
        Me.txtOSArchitecture = New System.Windows.Forms.TextBox()
        Me.txtSpecialrequirements = New System.Windows.Forms.TextBox()
        Me.txtFamily = New System.Windows.Forms.TextBox()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.txtCSName = New System.Windows.Forms.TextBox()
        Me.txtOSType = New System.Windows.Forms.TextBox()
        Me.txtOtheridentifyinginfo = New System.Windows.Forms.TextBox()
        Me.txtDatawidth = New System.Windows.Forms.TextBox()
        Me.txtBBName = New System.Windows.Forms.TextBox()
        Me.txtNumberoflogicalProcessors = New System.Windows.Forms.TextBox()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.txtNumberofcores = New System.Windows.Forms.TextBox()
        Me.txtHotswappable = New System.Windows.Forms.TextBox()
        Me.txtAddresswidth = New System.Windows.Forms.TextBox()
        Me.txtHostingbird = New System.Windows.Forms.TextBox()
        Me.txtNumberofProcessor = New System.Windows.Forms.TextBox()
        Me.txtDepth = New System.Windows.Forms.TextBox()
        Me.txtArchitecture = New System.Windows.Forms.TextBox()
        Me.txtConfigoptions = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtOSProductsuite = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.txtBuildType = New System.Windows.Forms.TextBox()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.txtBuildNumber = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(50, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(38, 22)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Visible = False
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNo.Location = New System.Drawing.Point(50, 73)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.ReadOnly = True
        Me.txtSerialNo.Size = New System.Drawing.Size(38, 22)
        Me.txtSerialNo.TabIndex = 11
        Me.txtSerialNo.Visible = False
        '
        'txtActivationID
        '
        Me.txtActivationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActivationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActivationID.Location = New System.Drawing.Point(50, 112)
        Me.txtActivationID.Name = "txtActivationID"
        Me.txtActivationID.Size = New System.Drawing.Size(38, 22)
        Me.txtActivationID.TabIndex = 12
        Me.txtActivationID.Visible = False
        '
        'txtHardwareID
        '
        Me.txtHardwareID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHardwareID.Location = New System.Drawing.Point(50, 45)
        Me.txtHardwareID.Name = "txtHardwareID"
        Me.txtHardwareID.ReadOnly = True
        Me.txtHardwareID.Size = New System.Drawing.Size(38, 22)
        Me.txtHardwareID.TabIndex = 10
        Me.txtHardwareID.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(2, 324)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(612, 5)
        Me.ProgressBar1.TabIndex = 14
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.BackColor = System.Drawing.Color.Transparent
        Me.lblSet.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSet.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblSet.Location = New System.Drawing.Point(13, 304)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(10, 13)
        Me.lblSet.TabIndex = 15
        Me.lblSet.Text = "."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(157, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 28)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Billing with Inventory System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(245, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Version 2.7.0.1"
        '
        'txtMaxclockspeed
        '
        Me.txtMaxclockspeed.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtMaxclockspeed.Location = New System.Drawing.Point(115, 280)
        Me.txtMaxclockspeed.Name = "txtMaxclockspeed"
        Me.txtMaxclockspeed.Size = New System.Drawing.Size(13, 20)
        Me.txtMaxclockspeed.TabIndex = 83
        Me.txtMaxclockspeed.Visible = False
        '
        'txtBBVersion
        '
        Me.txtBBVersion.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBBVersion.Location = New System.Drawing.Point(96, 285)
        Me.txtBBVersion.Name = "txtBBVersion"
        Me.txtBBVersion.Size = New System.Drawing.Size(13, 20)
        Me.txtBBVersion.TabIndex = 94
        Me.txtBBVersion.Visible = False
        '
        'txtPcSystemtype
        '
        Me.txtPcSystemtype.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtPcSystemtype.Location = New System.Drawing.Point(49, 259)
        Me.txtPcSystemtype.Name = "txtPcSystemtype"
        Me.txtPcSystemtype.Size = New System.Drawing.Size(20, 20)
        Me.txtPcSystemtype.TabIndex = 76
        Me.txtPcSystemtype.Visible = False
        '
        'txtBBManufacturer
        '
        Me.txtBBManufacturer.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBBManufacturer.Location = New System.Drawing.Point(371, 285)
        Me.txtBBManufacturer.Name = "txtBBManufacturer"
        Me.txtBBManufacturer.Size = New System.Drawing.Size(13, 20)
        Me.txtBBManufacturer.TabIndex = 88
        Me.txtBBManufacturer.Visible = False
        '
        'txtOSArchitecture
        '
        Me.txtOSArchitecture.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtOSArchitecture.Location = New System.Drawing.Point(352, 285)
        Me.txtOSArchitecture.Name = "txtOSArchitecture"
        Me.txtOSArchitecture.Size = New System.Drawing.Size(13, 20)
        Me.txtOSArchitecture.TabIndex = 70
        Me.txtOSArchitecture.Visible = False
        '
        'txtSpecialrequirements
        '
        Me.txtSpecialrequirements.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtSpecialrequirements.Location = New System.Drawing.Point(295, 259)
        Me.txtSpecialrequirements.Name = "txtSpecialrequirements"
        Me.txtSpecialrequirements.Size = New System.Drawing.Size(13, 20)
        Me.txtSpecialrequirements.TabIndex = 93
        Me.txtSpecialrequirements.Visible = False
        '
        'txtFamily
        '
        Me.txtFamily.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtFamily.Location = New System.Drawing.Point(244, 259)
        Me.txtFamily.Name = "txtFamily"
        Me.txtFamily.Size = New System.Drawing.Size(13, 20)
        Me.txtFamily.TabIndex = 82
        Me.txtFamily.Visible = False
        '
        'txtSKU
        '
        Me.txtSKU.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtSKU.Location = New System.Drawing.Point(333, 285)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(13, 20)
        Me.txtSKU.TabIndex = 92
        Me.txtSKU.Visible = False
        '
        'txtCSName
        '
        Me.txtCSName.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtCSName.Location = New System.Drawing.Point(371, 259)
        Me.txtCSName.Name = "txtCSName"
        Me.txtCSName.Size = New System.Drawing.Size(13, 20)
        Me.txtCSName.TabIndex = 65
        Me.txtCSName.Visible = False
        '
        'txtOSType
        '
        Me.txtOSType.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtOSType.Location = New System.Drawing.Point(94, 259)
        Me.txtOSType.Name = "txtOSType"
        Me.txtOSType.Size = New System.Drawing.Size(15, 20)
        Me.txtOSType.TabIndex = 72
        Me.txtOSType.Visible = False
        '
        'txtOtheridentifyinginfo
        '
        Me.txtOtheridentifyinginfo.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtOtheridentifyinginfo.Location = New System.Drawing.Point(314, 285)
        Me.txtOtheridentifyinginfo.Name = "txtOtheridentifyinginfo"
        Me.txtOtheridentifyinginfo.Size = New System.Drawing.Size(13, 20)
        Me.txtOtheridentifyinginfo.TabIndex = 91
        Me.txtOtheridentifyinginfo.Visible = False
        '
        'txtDatawidth
        '
        Me.txtDatawidth.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtDatawidth.Location = New System.Drawing.Point(225, 259)
        Me.txtDatawidth.Name = "txtDatawidth"
        Me.txtDatawidth.Size = New System.Drawing.Size(13, 20)
        Me.txtDatawidth.TabIndex = 81
        Me.txtDatawidth.Visible = False
        '
        'txtBBName
        '
        Me.txtBBName.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBBName.Location = New System.Drawing.Point(295, 284)
        Me.txtBBName.Name = "txtBBName"
        Me.txtBBName.Size = New System.Drawing.Size(13, 20)
        Me.txtBBName.TabIndex = 90
        Me.txtBBName.Visible = False
        '
        'txtNumberoflogicalProcessors
        '
        Me.txtNumberoflogicalProcessors.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtNumberoflogicalProcessors.Location = New System.Drawing.Point(16, 298)
        Me.txtNumberoflogicalProcessors.Name = "txtNumberoflogicalProcessors"
        Me.txtNumberoflogicalProcessors.Size = New System.Drawing.Size(20, 20)
        Me.txtNumberoflogicalProcessors.TabIndex = 75
        Me.txtNumberoflogicalProcessors.Visible = False
        '
        'txtModel
        '
        Me.txtModel.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtModel.Location = New System.Drawing.Point(276, 284)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(13, 20)
        Me.txtModel.TabIndex = 89
        Me.txtModel.Visible = False
        '
        'txtNumberofcores
        '
        Me.txtNumberofcores.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtNumberofcores.Location = New System.Drawing.Point(206, 259)
        Me.txtNumberofcores.Name = "txtNumberofcores"
        Me.txtNumberofcores.Size = New System.Drawing.Size(13, 20)
        Me.txtNumberofcores.TabIndex = 80
        Me.txtNumberofcores.Visible = False
        '
        'txtHotswappable
        '
        Me.txtHotswappable.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtHotswappable.Location = New System.Drawing.Point(352, 259)
        Me.txtHotswappable.Name = "txtHotswappable"
        Me.txtHotswappable.Size = New System.Drawing.Size(13, 20)
        Me.txtHotswappable.TabIndex = 87
        Me.txtHotswappable.Visible = False
        '
        'txtAddresswidth
        '
        Me.txtAddresswidth.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtAddresswidth.Location = New System.Drawing.Point(187, 259)
        Me.txtAddresswidth.Name = "txtAddresswidth"
        Me.txtAddresswidth.Size = New System.Drawing.Size(13, 20)
        Me.txtAddresswidth.TabIndex = 79
        Me.txtAddresswidth.Visible = False
        '
        'txtHostingbird
        '
        Me.txtHostingbird.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtHostingbird.Location = New System.Drawing.Point(333, 259)
        Me.txtHostingbird.Name = "txtHostingbird"
        Me.txtHostingbird.Size = New System.Drawing.Size(13, 20)
        Me.txtHostingbird.TabIndex = 86
        Me.txtHostingbird.Visible = False
        '
        'txtNumberofProcessor
        '
        Me.txtNumberofProcessor.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtNumberofProcessor.Location = New System.Drawing.Point(16, 277)
        Me.txtNumberofProcessor.Name = "txtNumberofProcessor"
        Me.txtNumberofProcessor.Size = New System.Drawing.Size(20, 20)
        Me.txtNumberofProcessor.TabIndex = 73
        Me.txtNumberofProcessor.Visible = False
        '
        'txtDepth
        '
        Me.txtDepth.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtDepth.Location = New System.Drawing.Point(314, 259)
        Me.txtDepth.Name = "txtDepth"
        Me.txtDepth.Size = New System.Drawing.Size(13, 20)
        Me.txtDepth.TabIndex = 85
        Me.txtDepth.Visible = False
        '
        'txtArchitecture
        '
        Me.txtArchitecture.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtArchitecture.Location = New System.Drawing.Point(168, 259)
        Me.txtArchitecture.Name = "txtArchitecture"
        Me.txtArchitecture.Size = New System.Drawing.Size(13, 20)
        Me.txtArchitecture.TabIndex = 78
        Me.txtArchitecture.Visible = False
        '
        'txtConfigoptions
        '
        Me.txtConfigoptions.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtConfigoptions.Location = New System.Drawing.Point(276, 259)
        Me.txtConfigoptions.Name = "txtConfigoptions"
        Me.txtConfigoptions.Size = New System.Drawing.Size(13, 20)
        Me.txtConfigoptions.TabIndex = 84
        Me.txtConfigoptions.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtDescription.Location = New System.Drawing.Point(149, 259)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(13, 20)
        Me.txtDescription.TabIndex = 77
        Me.txtDescription.Visible = False
        '
        'txtOSProductsuite
        '
        Me.txtOSProductsuite.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtOSProductsuite.Location = New System.Drawing.Point(16, 256)
        Me.txtOSProductsuite.Name = "txtOSProductsuite"
        Me.txtOSProductsuite.Size = New System.Drawing.Size(19, 20)
        Me.txtOSProductsuite.TabIndex = 69
        Me.txtOSProductsuite.Visible = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtName.Location = New System.Drawing.Point(130, 259)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(13, 20)
        Me.txtName.TabIndex = 74
        Me.txtName.Visible = False
        '
        'txtVersion
        '
        Me.txtVersion.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtVersion.Location = New System.Drawing.Point(56, 275)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(13, 20)
        Me.txtVersion.TabIndex = 64
        Me.txtVersion.Visible = False
        '
        'txtManufacturer
        '
        Me.txtManufacturer.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtManufacturer.Location = New System.Drawing.Point(115, 259)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(13, 20)
        Me.txtManufacturer.TabIndex = 71
        Me.txtManufacturer.Visible = False
        '
        'txtBuildType
        '
        Me.txtBuildType.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBuildType.Location = New System.Drawing.Point(71, 259)
        Me.txtBuildType.Name = "txtBuildType"
        Me.txtBuildType.Size = New System.Drawing.Size(19, 20)
        Me.txtBuildType.TabIndex = 68
        Me.txtBuildType.Visible = False
        '
        'txtCaption
        '
        Me.txtCaption.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtCaption.Location = New System.Drawing.Point(75, 280)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(13, 20)
        Me.txtCaption.TabIndex = 66
        Me.txtCaption.Visible = False
        '
        'txtBuildNumber
        '
        Me.txtBuildNumber.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBuildNumber.Location = New System.Drawing.Point(50, 295)
        Me.txtBuildNumber.Name = "txtBuildNumber"
        Me.txtBuildNumber.Size = New System.Drawing.Size(19, 20)
        Me.txtBuildNumber.TabIndex = 67
        Me.txtBuildNumber.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(591, 299)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(10, 10)
        Me.CrystalReportViewer1.TabIndex = 95
        Me.CrystalReportViewer1.Visible = False
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Sales_and_Inventory_System.My.Resources.Resources.packages__2_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(615, 329)
        Me.ControlBox = False
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtMaxclockspeed)
        Me.Controls.Add(Me.txtBBVersion)
        Me.Controls.Add(Me.txtPcSystemtype)
        Me.Controls.Add(Me.txtBBManufacturer)
        Me.Controls.Add(Me.txtOSArchitecture)
        Me.Controls.Add(Me.txtSpecialrequirements)
        Me.Controls.Add(Me.txtFamily)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.txtCSName)
        Me.Controls.Add(Me.txtOSType)
        Me.Controls.Add(Me.txtOtheridentifyinginfo)
        Me.Controls.Add(Me.txtDatawidth)
        Me.Controls.Add(Me.txtBBName)
        Me.Controls.Add(Me.txtNumberoflogicalProcessors)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.txtNumberofcores)
        Me.Controls.Add(Me.txtHotswappable)
        Me.Controls.Add(Me.txtAddresswidth)
        Me.Controls.Add(Me.txtHostingbird)
        Me.Controls.Add(Me.txtNumberofProcessor)
        Me.Controls.Add(Me.txtDepth)
        Me.Controls.Add(Me.txtArchitecture)
        Me.Controls.Add(Me.txtConfigoptions)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtOSProductsuite)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.txtManufacturer)
        Me.Controls.Add(Me.txtBuildType)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.txtBuildNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSet)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtSerialNo)
        Me.Controls.Add(Me.txtActivationID)
        Me.Controls.Add(Me.txtHardwareID)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents txtActivationID As System.Windows.Forms.TextBox
    Friend WithEvents txtHardwareID As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMaxclockspeed As System.Windows.Forms.TextBox
    Friend WithEvents txtBBVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtPcSystemtype As System.Windows.Forms.TextBox
    Friend WithEvents txtBBManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents txtOSArchitecture As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecialrequirements As System.Windows.Forms.TextBox
    Friend WithEvents txtFamily As System.Windows.Forms.TextBox
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents txtCSName As System.Windows.Forms.TextBox
    Friend WithEvents txtOSType As System.Windows.Forms.TextBox
    Friend WithEvents txtOtheridentifyinginfo As System.Windows.Forms.TextBox
    Friend WithEvents txtDatawidth As System.Windows.Forms.TextBox
    Friend WithEvents txtBBName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberoflogicalProcessors As System.Windows.Forms.TextBox
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberofcores As System.Windows.Forms.TextBox
    Friend WithEvents txtHotswappable As System.Windows.Forms.TextBox
    Friend WithEvents txtAddresswidth As System.Windows.Forms.TextBox
    Friend WithEvents txtHostingbird As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberofProcessor As System.Windows.Forms.TextBox
    Friend WithEvents txtDepth As System.Windows.Forms.TextBox
    Friend WithEvents txtArchitecture As System.Windows.Forms.TextBox
    Friend WithEvents txtConfigoptions As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtOSProductsuite As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents txtBuildType As System.Windows.Forms.TextBox
    Friend WithEvents txtCaption As System.Windows.Forms.TextBox
    Friend WithEvents txtBuildNumber As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
