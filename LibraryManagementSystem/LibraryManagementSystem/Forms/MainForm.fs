module Forms.MainForm

open System.Windows.Forms
open System
open System.Drawing
open Forms.ShowBooksForm
open Forms.AddBookForm
open BorrowBookForm
open ReturnBookForm
open CoreFunctions
open BookData
open Forms.SearchForms

type MainForm() as this =
    inherit Form()

    // Define UI components
    let titleLabel = new Label(
        Text = "Library Management System",
        Font = new Font("Segoe UI", 24f, FontStyle.Bold),
        AutoSize = true,
        Location = Point(330, 20),
        ForeColor = Color.Teal
    )

    let searchLabel = new Label(
        Text = "Search for a Book:",
        Font = new Font("Segoe UI", 12f),
        AutoSize = true,
        Location = Point(10, 80),
        ForeColor = Color.Gray
    )
    let searchArea = new TextBox(Width = 700, Height = 30, Location = Point(150, 75), BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle)
    let searchBtn = new Button(
        Text = "Search",
        Width = 100,
        Height = 30,
        Location = Point(870, 75),
        BackColor = Color.MediumSeaGreen,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat
    )

    let actionPanel = new Panel(BackColor = Color.WhiteSmoke, Size = Size(900, 300), Location = Point(100, 130))

    let addBookBtn = new Button(
        Text = "Add Book",
        Width = 150,
        Height = 150,
        Location = Point(20, 50),
        BackColor = Color.Teal,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10f, FontStyle.Bold)
    )
    let addBookLabel = new Label(
        Text = "Add new books to the system",
        Font = new Font("Segoe UI", 10f),
        AutoSize = true,
        Location = Point(25, 210),
        ForeColor = Color.Gray
    )

    let borrowBookBtn = new Button(
        Text = "Borrow Book",
        Width = 150,
        Height = 150,
        Location = Point(220, 50),
        BackColor = Color.Teal,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10f, FontStyle.Bold)
    )
    let borrowBookLabel = new Label(
        Text = "Borrow books from the library",
        Font = new Font("Segoe UI", 10f),
        AutoSize = true,
        Location = Point(225, 210),
        ForeColor = Color.Gray
    )

    let returnBookBtn = new Button(
        Text = "Return Book",
        Width = 150,
        Height = 150,
        Location = Point(420, 50),
        BackColor = Color.Teal,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10f, FontStyle.Bold)
    )
    let returnBookLabel = new Label(
        Text = "Return borrowed books",
        Font = new Font("Segoe UI", 10f),
        AutoSize = true,
        Location = Point(425, 210),
        ForeColor = Color.Gray
    )

    let showBooksBtn = new Button(
        Text = "Show Books",
        Width = 150,
        Height = 150,
        Location = Point(620, 50),
        BackColor = Color.Teal,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10f, FontStyle.Bold)
    )
    let showBooksLabel = new Label(
        Text = "View all books in the library",
        Font = new Font("Segoe UI", 10f),
        AutoSize = true,
        Location = Point(625, 210),
        ForeColor = Color.Gray
    )

    let exitBtn = new Button(
        Text = "Exit",
        Width = 150,
        Height = 40,
        Location = Point(870, 450),
        BackColor = Color.DarkRed,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat
    )

    // Initialize components
    do
        // Configure action panel
        actionPanel.Controls.AddRange([|
            addBookBtn; addBookLabel;
            borrowBookBtn; borrowBookLabel;
            returnBookBtn; returnBookLabel;
            showBooksBtn; showBooksLabel
        |])

        // Form setup
        this.Text <- "Library Management System"
        this.Size <- Size(1100, 600)
        this.StartPosition <- FormStartPosition.CenterScreen
        this.BackColor <- Color.LightGray

        // Add controls to the form
        this.Controls.Add(titleLabel)
        this.Controls.Add(searchLabel)
        this.Controls.Add(searchArea)
        this.Controls.Add(searchBtn)
        this.Controls.Add(actionPanel)
        this.Controls.Add(exitBtn)

        // Event handlers
        searchBtn.Click.Add(fun _ ->
            let searchText = searchArea.Text.Trim()
            if String.IsNullOrWhiteSpace(searchText) then
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore
            else
                let searchForm = new SearchForm(searchText)
                searchForm.Show() |> ignore
        )

        addBookBtn.Click.Add(fun _ ->
            let addBookForm = new AddBookForm()
            addBookForm.ShowDialog() |> ignore
        )

        borrowBookBtn.Click.Add(fun _ ->
            let borrowBookForm = new BorrowBookForm()
            borrowBookForm.ShowDialog() |> ignore
        )

   

        returnBookBtn.Click.Add(fun _ -> 
            // Open the ReturnBookForm when the "Return Book" button is clicked
            let returnBookForm = new ReturnBookForm()
            returnBookForm.ShowDialog() |> ignore
        )

        showBooksBtn.Click.Add(fun _ ->
            let showBooksForm = new ShowBooksForm()
            showBooksForm.Show() |> ignore
        )

        exitBtn.Click.Add(fun _ -> Application.Exit())
