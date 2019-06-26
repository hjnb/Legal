Public Class TopForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Legal.mdb"
    Public DB_Legal As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Legal.xls"

    '画像パス
    Public topImageFilePath As String = My.Application.Info.DirectoryPath & "\Legal.PNG"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        'If Not System.IO.File.Exists(excelFilePass) Then
        '    MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
        '    Me.Close()
        '    Exit Sub
        'End If

        If Not System.IO.File.Exists(topImageFilePath) Then
            MsgBox("トップ画像ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        '画像の配置処理
        PicBox.ImageLocation = topImageFilePath

        '西暦ボックスの初期設定
        initYYBox()

        'データグリッドビュー初期設定
        initDgvHol()
    End Sub

    ''' <summary>
    ''' 画像クリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PicBox_Click(sender As System.Object, e As System.EventArgs) Handles PicBox.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 西暦ボックス初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initYYBox()
        'クリア
        yyBox.Items.Clear()

        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Legal)
        Dim sql As String = "select distinct YY from Hol order by YY Desc"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim yy As String = Util.checkDBNullValue(rs.Fields("YY").Value)
            yyBox.Items.Add(yy)
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvHol()
        Util.EnableDoubleBuffering(dgvHol)

        With dgvHol
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .RowHeadersVisible = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowTemplate.Height = 18
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
            '.Font = New Font("ＭＳ Ｐゴシック", 9)
        End With
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvHol(year As String)
        'クリア
        dgvHol.Columns.Clear()





    End Sub

    ''' <summary>
    ''' 西暦ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub yyBox_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles yyBox.SelectedIndexChanged
        displayDgvHol(yyBox.Text)
    End Sub
End Class
