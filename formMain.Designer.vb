<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose( disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMain))
        Me.textExpression = New System.Windows.Forms.TextBox()
        Me.textResult = New System.Windows.Forms.TextBox()
        Me.sizeTesterExpression = New System.Windows.Forms.Label()
        Me.sizeTesterResult = New System.Windows.Forms.Label()
        Me.panelSettings = New System.Windows.Forms.Panel()
        Me.menuSettings = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExpression = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExtract = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuFraction = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBracket = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuInvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMultiply = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRoot = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSquare = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCube = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuAddPlus = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSizeSmall = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSizeRegular = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSizeLarge = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuSizeSmaller = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSizeLarger = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSizeReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThemeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HotPinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElegantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhiteboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuWindowAutoBorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuWindowOnTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuWindowTranslucent = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity90 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity80 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity75 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpacity5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormattingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSeparateThousands = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRoundInteger = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound2dp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound3dp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound4dp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound5dp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRound6dp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuPasteAnswer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCopyExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.infoTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.timerSave = New System.Windows.Forms.Timer(Me.components)
        Me.generalTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.menuSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'textExpression
        '
        Me.textExpression.BackColor = System.Drawing.Color.Black
        Me.textExpression.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textExpression.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textExpression.ForeColor = System.Drawing.Color.White
        Me.textExpression.Location = New System.Drawing.Point(10, 10)
        Me.textExpression.Name = "textExpression"
        Me.textExpression.Size = New System.Drawing.Size(312, 45)
        Me.textExpression.TabIndex = 0
        Me.textExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textResult
        '
        Me.textResult.BackColor = System.Drawing.Color.Black
        Me.textResult.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.textResult.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textResult.ForeColor = System.Drawing.Color.White
        Me.textResult.Location = New System.Drawing.Point(328, 10)
        Me.textResult.Name = "textResult"
        Me.textResult.ReadOnly = True
        Me.textResult.Size = New System.Drawing.Size(312, 45)
        Me.textResult.TabIndex = 1
        '
        'sizeTesterExpression
        '
        Me.sizeTesterExpression.AutoSize = True
        Me.sizeTesterExpression.BackColor = System.Drawing.Color.Fuchsia
        Me.sizeTesterExpression.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sizeTesterExpression.Location = New System.Drawing.Point(254, 74)
        Me.sizeTesterExpression.Name = "sizeTesterExpression"
        Me.sizeTesterExpression.Size = New System.Drawing.Size(143, 45)
        Me.sizeTesterExpression.TabIndex = 2
        Me.sizeTesterExpression.Text = "Label1"
        Me.sizeTesterExpression.Visible = False
        '
        'sizeTesterResult
        '
        Me.sizeTesterResult.AutoSize = True
        Me.sizeTesterResult.BackColor = System.Drawing.Color.Fuchsia
        Me.sizeTesterResult.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sizeTesterResult.Location = New System.Drawing.Point(347, 74)
        Me.sizeTesterResult.Name = "sizeTesterResult"
        Me.sizeTesterResult.Size = New System.Drawing.Size(143, 45)
        Me.sizeTesterResult.TabIndex = 3
        Me.sizeTesterResult.Text = "Label1"
        Me.sizeTesterResult.Visible = False
        '
        'panelSettings
        '
        Me.panelSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.panelSettings.Location = New System.Drawing.Point(632, 49)
        Me.panelSettings.Name = "panelSettings"
        Me.panelSettings.Size = New System.Drawing.Size(16, 16)
        Me.panelSettings.TabIndex = 4
        Me.generalTip.SetToolTip(Me.panelSettings, "Opens the settings menu")
        '
        'menuSettings
        '
        Me.menuSettings.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuHistory, Me.menuExpression, Me.menuSize, Me.ThemeToolStripMenuItem, Me.WindowToolStripMenuItem, Me.FormattingToolStripMenuItem, Me.ToolStripMenuItem5, Me.menuAbout, Me.menuUpdates, Me.ToolStripSeparator1, Me.menuPasteAnswer, Me.menuCopyExit, Me.menuExit})
        Me.menuSettings.Name = "menuSettings"
        Me.menuSettings.Size = New System.Drawing.Size(211, 258)
        Me.menuSettings.Text = "Menu"
        '
        'menuHistory
        '
        Me.menuHistory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7})
        Me.menuHistory.Name = "menuHistory"
        Me.menuHistory.Size = New System.Drawing.Size(210, 22)
        Me.menuHistory.Text = "History"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(57, 6)
        '
        'menuExpression
        '
        Me.menuExpression.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNew, Me.menuDuplicate, Me.menuExtract, Me.ToolStripMenuItem6, Me.menuFraction, Me.menuBracket, Me.menuInvert, Me.menuMultiply, Me.menuRoot, Me.menuSquare, Me.menuCube, Me.ToolStripMenuItem1, Me.menuAddPlus})
        Me.menuExpression.Name = "menuExpression"
        Me.menuExpression.Size = New System.Drawing.Size(210, 22)
        Me.menuExpression.Text = "Expression"
        '
        'menuNew
        '
        Me.menuNew.Name = "menuNew"
        Me.menuNew.ShortcutKeyDisplayString = "Ctrl + N"
        Me.menuNew.Size = New System.Drawing.Size(192, 22)
        Me.menuNew.Text = "New"
        Me.menuNew.ToolTipText = "Creates a new Kalq window"
        '
        'menuDuplicate
        '
        Me.menuDuplicate.Name = "menuDuplicate"
        Me.menuDuplicate.ShortcutKeyDisplayString = "Ctrl + D"
        Me.menuDuplicate.Size = New System.Drawing.Size(192, 22)
        Me.menuDuplicate.Text = "Duplicate"
        Me.menuDuplicate.ToolTipText = "Creates a new Kalq window with existing expression"
        '
        'menuExtract
        '
        Me.menuExtract.Name = "menuExtract"
        Me.menuExtract.ShortcutKeyDisplayString = "Ctrl + E"
        Me.menuExtract.Size = New System.Drawing.Size(192, 22)
        Me.menuExtract.Text = "Extract"
        Me.menuExtract.ToolTipText = "Creates a new Kalq window with selected text"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(189, 6)
        '
        'menuFraction
        '
        Me.menuFraction.Name = "menuFraction"
        Me.menuFraction.ShortcutKeyDisplayString = "Ctrl + F"
        Me.menuFraction.Size = New System.Drawing.Size(192, 22)
        Me.menuFraction.Text = "Fraction"
        '
        'menuBracket
        '
        Me.menuBracket.Name = "menuBracket"
        Me.menuBracket.ShortcutKeyDisplayString = "Ctrl + G"
        Me.menuBracket.Size = New System.Drawing.Size(192, 22)
        Me.menuBracket.Text = "Bracket"
        '
        'menuInvert
        '
        Me.menuInvert.Name = "menuInvert"
        Me.menuInvert.ShortcutKeyDisplayString = "Ctrl + I"
        Me.menuInvert.Size = New System.Drawing.Size(192, 22)
        Me.menuInvert.Text = "Inversion"
        '
        'menuMultiply
        '
        Me.menuMultiply.Name = "menuMultiply"
        Me.menuMultiply.ShortcutKeyDisplayString = "Ctrl + M"
        Me.menuMultiply.Size = New System.Drawing.Size(192, 22)
        Me.menuMultiply.Text = "Multiply"
        '
        'menuRoot
        '
        Me.menuRoot.Name = "menuRoot"
        Me.menuRoot.ShortcutKeyDisplayString = "Ctrl + R"
        Me.menuRoot.Size = New System.Drawing.Size(192, 22)
        Me.menuRoot.Text = "Square root"
        '
        'menuSquare
        '
        Me.menuSquare.Name = "menuSquare"
        Me.menuSquare.ShortcutKeyDisplayString = "Ctrl + 2"
        Me.menuSquare.Size = New System.Drawing.Size(192, 22)
        Me.menuSquare.Text = "Square"
        '
        'menuCube
        '
        Me.menuCube.Name = "menuCube"
        Me.menuCube.ShortcutKeyDisplayString = "Ctrl + 3"
        Me.menuCube.Size = New System.Drawing.Size(192, 22)
        Me.menuCube.Text = "Cube"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(189, 6)
        '
        'menuAddPlus
        '
        Me.menuAddPlus.Name = "menuAddPlus"
        Me.menuAddPlus.ShortcutKeyDisplayString = "Shift + Enter"
        Me.menuAddPlus.Size = New System.Drawing.Size(192, 22)
        Me.menuAddPlus.Text = "Add plus"
        '
        'menuSize
        '
        Me.menuSize.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSizeSmall, Me.menuSizeRegular, Me.menuSizeLarge, Me.ToolStripMenuItem3, Me.menuSizeSmaller, Me.menuSizeLarger, Me.menuSizeReset})
        Me.menuSize.Name = "menuSize"
        Me.menuSize.Size = New System.Drawing.Size(210, 22)
        Me.menuSize.Text = "Size"
        '
        'menuSizeSmall
        '
        Me.menuSizeSmall.Name = "menuSizeSmall"
        Me.menuSizeSmall.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeSmall.Text = "Small"
        Me.menuSizeSmall.Visible = False
        '
        'menuSizeRegular
        '
        Me.menuSizeRegular.Name = "menuSizeRegular"
        Me.menuSizeRegular.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeRegular.Text = "Regular"
        Me.menuSizeRegular.Visible = False
        '
        'menuSizeLarge
        '
        Me.menuSizeLarge.Name = "menuSizeLarge"
        Me.menuSizeLarge.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeLarge.Text = "Large"
        Me.menuSizeLarge.Visible = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(151, 6)
        Me.ToolStripMenuItem3.Visible = False
        '
        'menuSizeSmaller
        '
        Me.menuSizeSmaller.Name = "menuSizeSmaller"
        Me.menuSizeSmaller.ShortcutKeyDisplayString = "Ctrl + -"
        Me.menuSizeSmaller.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeSmaller.Text = "Smaller"
        '
        'menuSizeLarger
        '
        Me.menuSizeLarger.Name = "menuSizeLarger"
        Me.menuSizeLarger.ShortcutKeyDisplayString = "Ctrl + +"
        Me.menuSizeLarger.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeLarger.Text = "Larger"
        '
        'menuSizeReset
        '
        Me.menuSizeReset.Name = "menuSizeReset"
        Me.menuSizeReset.ShortcutKeyDisplayString = "Ctrl + 0"
        Me.menuSizeReset.Size = New System.Drawing.Size(154, 22)
        Me.menuSizeReset.Text = "Reset"
        '
        'ThemeToolStripMenuItem
        '
        Me.ThemeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassicToolStripMenuItem, Me.InvertedToolStripMenuItem, Me.HotPinkToolStripMenuItem, Me.ElegantToolStripMenuItem, Me.WhiteboardToolStripMenuItem})
        Me.ThemeToolStripMenuItem.Name = "ThemeToolStripMenuItem"
        Me.ThemeToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ThemeToolStripMenuItem.Text = "Style"
        Me.ThemeToolStripMenuItem.Visible = False
        '
        'ClassicToolStripMenuItem
        '
        Me.ClassicToolStripMenuItem.Name = "ClassicToolStripMenuItem"
        Me.ClassicToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ClassicToolStripMenuItem.Text = "Classic"
        '
        'InvertedToolStripMenuItem
        '
        Me.InvertedToolStripMenuItem.Name = "InvertedToolStripMenuItem"
        Me.InvertedToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.InvertedToolStripMenuItem.Text = "Inverted"
        '
        'HotPinkToolStripMenuItem
        '
        Me.HotPinkToolStripMenuItem.Name = "HotPinkToolStripMenuItem"
        Me.HotPinkToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.HotPinkToolStripMenuItem.Text = "Hot Pink"
        '
        'ElegantToolStripMenuItem
        '
        Me.ElegantToolStripMenuItem.Name = "ElegantToolStripMenuItem"
        Me.ElegantToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ElegantToolStripMenuItem.Text = "Elegant"
        '
        'WhiteboardToolStripMenuItem
        '
        Me.WhiteboardToolStripMenuItem.Name = "WhiteboardToolStripMenuItem"
        Me.WhiteboardToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.WhiteboardToolStripMenuItem.Text = "Whiteboard"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuWindowAutoBorder, Me.menuWindowOnTop, Me.menuWindowTranslucent})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'menuWindowAutoBorder
        '
        Me.menuWindowAutoBorder.Checked = True
        Me.menuWindowAutoBorder.CheckOnClick = True
        Me.menuWindowAutoBorder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuWindowAutoBorder.Name = "menuWindowAutoBorder"
        Me.menuWindowAutoBorder.Size = New System.Drawing.Size(182, 22)
        Me.menuWindowAutoBorder.Text = "Auto window border"
        '
        'menuWindowOnTop
        '
        Me.menuWindowOnTop.Checked = True
        Me.menuWindowOnTop.CheckOnClick = True
        Me.menuWindowOnTop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuWindowOnTop.Name = "menuWindowOnTop"
        Me.menuWindowOnTop.Size = New System.Drawing.Size(182, 22)
        Me.menuWindowOnTop.Text = "Always on top"
        '
        'menuWindowTranslucent
        '
        Me.menuWindowTranslucent.CheckOnClick = True
        Me.menuWindowTranslucent.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuOpacity100, Me.menuOpacity90, Me.menuOpacity80, Me.menuOpacity75, Me.menuOpacity50, Me.menuOpacity33, Me.menuOpacity20, Me.menuOpacity10, Me.menuOpacity5})
        Me.menuWindowTranslucent.Name = "menuWindowTranslucent"
        Me.menuWindowTranslucent.Size = New System.Drawing.Size(182, 22)
        Me.menuWindowTranslucent.Text = "Opacity"
        Me.menuWindowTranslucent.Visible = False
        '
        'menuOpacity100
        '
        Me.menuOpacity100.Name = "menuOpacity100"
        Me.menuOpacity100.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity100.Text = "100%"
        '
        'menuOpacity90
        '
        Me.menuOpacity90.Name = "menuOpacity90"
        Me.menuOpacity90.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity90.Text = "90%"
        '
        'menuOpacity80
        '
        Me.menuOpacity80.Name = "menuOpacity80"
        Me.menuOpacity80.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity80.Text = "80%"
        '
        'menuOpacity75
        '
        Me.menuOpacity75.Name = "menuOpacity75"
        Me.menuOpacity75.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity75.Text = "75%"
        '
        'menuOpacity50
        '
        Me.menuOpacity50.Name = "menuOpacity50"
        Me.menuOpacity50.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity50.Text = "50%"
        '
        'menuOpacity33
        '
        Me.menuOpacity33.Name = "menuOpacity33"
        Me.menuOpacity33.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity33.Text = "33%"
        '
        'menuOpacity20
        '
        Me.menuOpacity20.Name = "menuOpacity20"
        Me.menuOpacity20.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity20.Text = "20%"
        '
        'menuOpacity10
        '
        Me.menuOpacity10.Name = "menuOpacity10"
        Me.menuOpacity10.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity10.Text = "10%"
        '
        'menuOpacity5
        '
        Me.menuOpacity5.Name = "menuOpacity5"
        Me.menuOpacity5.Size = New System.Drawing.Size(101, 22)
        Me.menuOpacity5.Text = "5%"
        '
        'FormattingToolStripMenuItem
        '
        Me.FormattingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSeparateThousands, Me.menuRound})
        Me.FormattingToolStripMenuItem.Name = "FormattingToolStripMenuItem"
        Me.FormattingToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.FormattingToolStripMenuItem.Text = "Formatting"
        '
        'menuSeparateThousands
        '
        Me.menuSeparateThousands.Checked = True
        Me.menuSeparateThousands.CheckOnClick = True
        Me.menuSeparateThousands.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuSeparateThousands.Name = "menuSeparateThousands"
        Me.menuSeparateThousands.Size = New System.Drawing.Size(177, 22)
        Me.menuSeparateThousands.Text = "Separate thousands"
        '
        'menuRound
        '
        Me.menuRound.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRoundInteger, Me.menuRound2dp, Me.menuRound3dp, Me.menuRound4dp, Me.menuRound5dp, Me.menuRound6dp})
        Me.menuRound.Name = "menuRound"
        Me.menuRound.Size = New System.Drawing.Size(177, 22)
        Me.menuRound.Text = "Round decimals"
        Me.menuRound.Visible = False
        '
        'menuRoundInteger
        '
        Me.menuRoundInteger.Name = "menuRoundInteger"
        Me.menuRoundInteger.Size = New System.Drawing.Size(157, 22)
        Me.menuRoundInteger.Text = "Closest integer"
        '
        'menuRound2dp
        '
        Me.menuRound2dp.Name = "menuRound2dp"
        Me.menuRound2dp.Size = New System.Drawing.Size(157, 22)
        Me.menuRound2dp.Text = "2 decimal places"
        '
        'menuRound3dp
        '
        Me.menuRound3dp.Name = "menuRound3dp"
        Me.menuRound3dp.Size = New System.Drawing.Size(157, 22)
        Me.menuRound3dp.Text = "3 decimal places"
        '
        'menuRound4dp
        '
        Me.menuRound4dp.Name = "menuRound4dp"
        Me.menuRound4dp.Size = New System.Drawing.Size(157, 22)
        Me.menuRound4dp.Text = "4 decimal places"
        '
        'menuRound5dp
        '
        Me.menuRound5dp.Name = "menuRound5dp"
        Me.menuRound5dp.Size = New System.Drawing.Size(157, 22)
        Me.menuRound5dp.Text = "5 decimal places"
        '
        'menuRound6dp
        '
        Me.menuRound6dp.Name = "menuRound6dp"
        Me.menuRound6dp.Size = New System.Drawing.Size(157, 22)
        Me.menuRound6dp.Text = "6 decimal places"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(207, 6)
        '
        'menuAbout
        '
        Me.menuAbout.Enabled = False
        Me.menuAbout.Name = "menuAbout"
        Me.menuAbout.ShortcutKeyDisplayString = ""
        Me.menuAbout.Size = New System.Drawing.Size(210, 22)
        Me.menuAbout.Text = "Kalq 1.0.0 by Jaywick Labs"
        '
        'menuUpdates
        '
        Me.menuUpdates.Name = "menuUpdates"
        Me.menuUpdates.Size = New System.Drawing.Size(210, 22)
        Me.menuUpdates.Text = "Check for updates"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'menuPasteAnswer
        '
        Me.menuPasteAnswer.Name = "menuPasteAnswer"
        Me.menuPasteAnswer.ShortcutKeyDisplayString = "Ctrl + Enter"
        Me.menuPasteAnswer.Size = New System.Drawing.Size(210, 22)
        Me.menuPasteAnswer.Text = "Paste answer"
        '
        'menuCopyExit
        '
        Me.menuCopyExit.Name = "menuCopyExit"
        Me.menuCopyExit.ShortcutKeyDisplayString = "Enter"
        Me.menuCopyExit.Size = New System.Drawing.Size(210, 22)
        Me.menuCopyExit.Text = "Copy result and Exit"
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.ShortcutKeyDisplayString = "Esc"
        Me.menuExit.Size = New System.Drawing.Size(210, 22)
        Me.menuExit.Text = "Exit"
        '
        'infoTip
        '
        Me.infoTip.IsBalloon = True
        Me.infoTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.[Error]
        Me.infoTip.ToolTipTitle = "Syntax Error"
        Me.infoTip.UseAnimation = False
        Me.infoTip.UseFading = False
        '
        'timerSave
        '
        Me.timerSave.Interval = 2500
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(647, 64)
        Me.Controls.Add(Me.panelSettings)
        Me.Controls.Add(Me.sizeTesterResult)
        Me.Controls.Add(Me.sizeTesterExpression)
        Me.Controls.Add(Me.textResult)
        Me.Controls.Add(Me.textExpression)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "formMain"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Kalq"
        Me.TopMost = True
        Me.menuSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textExpression As System.Windows.Forms.TextBox
    Friend WithEvents textResult As System.Windows.Forms.TextBox
    Friend WithEvents sizeTesterExpression As System.Windows.Forms.Label
    Friend WithEvents sizeTesterResult As System.Windows.Forms.Label
    Friend WithEvents panelSettings As System.Windows.Forms.Panel
    Friend WithEvents menuSettings As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCopyExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSizeSmall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSizeRegular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSizeLarge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuSizeSmaller As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSizeLarger As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSizeReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExpression As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFraction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuBracket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExtract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMultiply As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThemeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HotPinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElegantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhiteboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuWindowOnTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuWindowAutoBorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormattingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSeparateThousands As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRoot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSquare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRoundInteger As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound2dp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound3dp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound6dp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound4dp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuWindowTranslucent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity90 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity80 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity75 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity33 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuOpacity5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRound5dp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents infoTip As System.Windows.Forms.ToolTip
    Friend WithEvents menuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDuplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCube As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerSave As System.Windows.Forms.Timer
    Friend WithEvents menuHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents generalTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuAddPlus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPasteAnswer As System.Windows.Forms.ToolStripMenuItem

End Class
