Imports System.Data.OleDb

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

        dateBox.canEnterKeyDown = True
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

        '現在年のデータ表示
        yyBox.Text = DateTime.Now.ToString("yyyy")
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
            .DefaultCellStyle.SelectionBackColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .RowHeadersVisible = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowTemplate.Height = 17
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

        'データ取得、表示
        Dim cnn As New ADODB.Connection
        cnn.Open(DB_Legal)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select MD, Hol from Hol where YY = '" & year & "' order by MD"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Hol")
        Dim dt As DataTable = ds.Tables("Hol")
        dgvHol.DataSource = dt
        If Not IsNothing(dgvHol.CurrentRow) Then
            dgvHol.CurrentRow.Selected = False
        End If

        '幅設定等
        With dgvHol
            With .Columns("MD")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Hol")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 100
            End With
        End With



    End Sub

    ''' <summary>
    ''' 西暦ボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub yyBox_TextChanged(sender As Object, e As System.EventArgs) Handles yyBox.TextChanged
        displayDgvHol(yyBox.Text)
    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvHol_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvHol.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim yy As String = yyBox.Text
            Dim md As String = Util.checkDBNullValue(dgvHol("MD", e.RowIndex).Value)
            Dim hol As String = Util.checkDBNullValue(dgvHol("Hol", e.RowIndex).Value)

            'セット
            dateBox.setADStr(yy & "/" & md)
            holBox.Text = hol

            'フォーカス
            dateBox.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 日付ボックスエンターキーイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dateBox_keyDownEnter(sender As Object, e As System.EventArgs) Handles dateBox.keyDownEnterOrDown
        holBox.Focus()
    End Sub

    ''' <summary>
    ''' テキストボックスキーダウン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub holBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles holBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegist.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 行登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '入力日付
        Dim ymd As String = dateBox.getADStr()
        If ymd = "" Then
            MsgBox("日付を入力して下さい。", MsgBoxStyle.Exclamation)
            dateBox.Focus()
            Return
        End If
        '年(YY)
        Dim yy As String = ymd.Substring(0, 4)
        'MD
        Dim md As String = ymd.Substring(5, 5)
        '内容
        Dim hol As String = holBox.Text
        If hol = "" Then
            MsgBox("祝祭日名を入力して下さい。", MsgBoxStyle.Exclamation)
            holBox.Focus()
            Return
        End If

    End Sub

    ''' <summary>
    ''' 行削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub
End Class
