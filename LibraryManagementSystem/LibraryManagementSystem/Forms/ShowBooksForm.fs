module Forms.ShowBooksForm

open System
open System.Windows.Forms
open System.Drawing

type ShowBooksForm() as this = 
    inherit Form()

    let dataGridView = new DataGridView(Dock = DockStyle.Fill, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill)

    // Grid columns (add more if you need)
    let addColumns() =
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Book ID", Name = "BookID")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Title", Name = "Title")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Author", Name = "Author")) |> ignore

        //Borrow book btn
        let borrowButtonColumn = new DataGridViewButtonColumn(HeaderText = "Borrow", Text = "Borrow", UseColumnTextForButtonValue = true)
        dataGridView.Columns.Add(borrowButtonColumn) |> ignore

        //Return book btn
        let ReturnButtonColumn = new DataGridViewButtonColumn(HeaderText = "Return", Text = "Return", UseColumnTextForButtonValue = true)
        dataGridView.Columns.Add(ReturnButtonColumn) |> ignore

    
    // Initialize components
    do
        this.Text <- "BooksList"
        this.Size <- Size(1100, 600)
        this.StartPosition <- FormStartPosition.CenterScreen
        addColumns()
        this.Controls.Add(dataGridView)