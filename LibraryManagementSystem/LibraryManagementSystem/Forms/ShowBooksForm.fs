module Forms.ShowBooksForm

open System
open System.Windows.Forms
open System.Drawing
open BookData // Importing BookData to access booksMap

type ShowBooksForm() as this = 
    inherit Form()

    let dataGridView = new DataGridView(Dock = DockStyle.Fill, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill)

    // Grid columns (add more if you need)
    let addColumns() =
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Book ID", Name = "BookID")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Title", Name = "Title")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Author", Name = "Author")) |> ignore

        // Borrow book button
        let borrowButtonColumn = new DataGridViewButtonColumn(HeaderText = "Borrow", Text = "Borrow", UseColumnTextForButtonValue = true)
        dataGridView.Columns.Add(borrowButtonColumn) |> ignore

        // Return book button
        let returnButtonColumn = new DataGridViewButtonColumn(HeaderText = "Return", Text = "Return", UseColumnTextForButtonValue = true)
        dataGridView.Columns.Add(returnButtonColumn) |> ignore

    // Populate the DataGridView with books from booksMap
    let populateGrid() =
        dataGridView.Rows.Clear() // Clear existing rows
        for kvp in booksMap do
            let book = kvp.Value
            let row = dataGridView.Rows.Add(kvp.Key, book.Title, book.Author) // Add the book details
            let rowIndex = dataGridView.Rows.Count - 1
            dataGridView.Rows[rowIndex].Cells.[3].Value <- "Borrow" // Set button text for Borrow
            dataGridView.Rows[rowIndex].Cells.[4].Value <- "Return" // Set button text for Return

    // Initialize components
    do
        this.Text <- "Books List"
        this.Size <- Size(1100, 600)
        this.StartPosition <- FormStartPosition.CenterScreen
        addColumns()
        this.Controls.Add(dataGridView)
        populateGrid() // Populate the grid when the form is initialized

        // Event handlers for button clicks
        dataGridView.CellContentClick.Add(fun args ->
            if args.ColumnIndex = 3 then // Borrow button clicked
                let title = dataGridView.Rows.[args.RowIndex].Cells.[1].Value.ToString()
                // Add your borrow logic here
                MessageBox.Show($"Borrowing book: {title}", "Borrow Book", MessageBoxButtons.OK) |> ignore
            elif args.ColumnIndex = 4 then // Return button clicked
                let title = dataGridView.Rows.[args.RowIndex].Cells.[1].Value.ToString()
                // Add your return logic here
                MessageBox.Show($"Returning book: {title}", "Return Book", MessageBoxButtons.OK) |> ignore
        )