<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.yyBox = New System.Windows.Forms.ComboBox()
        Me.dgvHol = New System.Windows.Forms.DataGridView()
        Me.dateBox = New ymdBox.ymdBox()
        Me.holBox = New System.Windows.Forms.TextBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnDeleteYear = New System.Windows.Forms.Button()
        Me.btnCreateYear = New System.Windows.Forms.Button()
        Me.PicBox = New System.Windows.Forms.PictureBox()
        CType(Me.dgvHol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'yyBox
        '
        Me.yyBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.yyBox.FormattingEnabled = True
        Me.yyBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.yyBox.Location = New System.Drawing.Point(21, 17)
        Me.yyBox.MaxLength = 4
        Me.yyBox.Name = "yyBox"
        Me.yyBox.Size = New System.Drawing.Size(64, 23)
        Me.yyBox.TabIndex = 0
        '
        'dgvHol
        '
        Me.dgvHol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHol.Location = New System.Drawing.Point(102, 17)
        Me.dgvHol.Name = "dgvHol"
        Me.dgvHol.RowTemplate.Height = 21
        Me.dgvHol.Size = New System.Drawing.Size(178, 428)
        Me.dgvHol.TabIndex = 1
        '
        'dateBox
        '
        Me.dateBox.boxType = 4
        Me.dateBox.DateText = ""
        Me.dateBox.EraLabelText = "R01"
        Me.dateBox.EraText = ""
        Me.dateBox.Location = New System.Drawing.Point(301, 214)
        Me.dateBox.MonthLabelText = "08"
        Me.dateBox.MonthText = ""
        Me.dateBox.Name = "dateBox"
        Me.dateBox.Size = New System.Drawing.Size(145, 34)
        Me.dateBox.TabIndex = 3
        Me.dateBox.textReadOnly = False
        '
        'holBox
        '
        Me.holBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.holBox.Location = New System.Drawing.Point(302, 264)
        Me.holBox.Name = "holBox"
        Me.holBox.Size = New System.Drawing.Size(118, 19)
        Me.holBox.TabIndex = 4
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(304, 300)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(58, 24)
        Me.btnRegist.TabIndex = 5
        Me.btnRegist.Text = "行登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(361, 300)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(58, 24)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "行削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnDeleteYear
        '
        Me.btnDeleteYear.Location = New System.Drawing.Point(361, 323)
        Me.btnDeleteYear.Name = "btnDeleteYear"
        Me.btnDeleteYear.Size = New System.Drawing.Size(58, 24)
        Me.btnDeleteYear.TabIndex = 8
        Me.btnDeleteYear.Text = "年抹消"
        Me.btnDeleteYear.UseVisualStyleBackColor = True
        '
        'btnCreateYear
        '
        Me.btnCreateYear.Location = New System.Drawing.Point(304, 323)
        Me.btnCreateYear.Name = "btnCreateYear"
        Me.btnCreateYear.Size = New System.Drawing.Size(58, 24)
        Me.btnCreateYear.TabIndex = 7
        Me.btnCreateYear.Text = "年生成"
        Me.btnCreateYear.UseVisualStyleBackColor = True
        '
        'PicBox
        '
        Me.PicBox.Location = New System.Drawing.Point(304, 87)
        Me.PicBox.Name = "PicBox"
        Me.PicBox.Size = New System.Drawing.Size(115, 92)
        Me.PicBox.TabIndex = 9
        Me.PicBox.TabStop = False
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 459)
        Me.Controls.Add(Me.PicBox)
        Me.Controls.Add(Me.btnDeleteYear)
        Me.Controls.Add(Me.btnCreateYear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.holBox)
        Me.Controls.Add(Me.dateBox)
        Me.Controls.Add(Me.dgvHol)
        Me.Controls.Add(Me.yyBox)
        Me.Name = "TopForm"
        Me.Text = "祝祭日"
        CType(Me.dgvHol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents yyBox As System.Windows.Forms.ComboBox
    Friend WithEvents dgvHol As System.Windows.Forms.DataGridView
    Friend WithEvents dateBox As ymdBox.ymdBox
    Friend WithEvents holBox As System.Windows.Forms.TextBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDeleteYear As System.Windows.Forms.Button
    Friend WithEvents btnCreateYear As System.Windows.Forms.Button
    Friend WithEvents PicBox As System.Windows.Forms.PictureBox

End Class
