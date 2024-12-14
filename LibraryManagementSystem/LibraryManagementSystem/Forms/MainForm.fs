module Forms.MainForm

open System.Windows.Forms
open System
open System.Drawing
open Forms.ShowBooksForm
open Forms.AddBookForm
open BorrowedBookForm
open CoreFunctions
open BookData
open Forms.SearchForms

type MainForm() as this =
    inherit Form()

    // Define UI components
    let searchBtn = new Button(Text = "Search", Width = 150, Height = 30, BackColor = Drawing.Color.LightCoral, Location = Point(910, 25)) 
    let searchArea = new TextBox(Name = "Search_Box", Width = 900, Height = 30, Multiline = true, Location = Point(2, 25))
    let searchLabel = new Label(Text = "Search a book:", Location = Point(0, 0)) 
    let addBookBtn = new Button(Text = "Add Book", Width = 400, Height = 100, Location = Point(10, 100), Font = new Font("", 20f), BackColor = Color.MediumAquamarine)
    let returnBookBtn = new Button(Text = "Return Book", Width = 400, Height = 100, Location = Point(670, 100), Font = new Font("", 20f), BackColor = Color.MediumAquamarine)
    let showBooksBtn = new Button(Text = "Show Books", Width = 400, Height = 100, Location = Point(10, 250), Font = new Font("", 20f), BackColor = Color.MediumAquamarine)
    let borrowBookBtn = new Button(Text = "Borrow Book", Width = 400, Height = 100, Location = Point(670, 250), Font = new Font("", 20f), BackColor = Color.MediumAquamarine)
    let exitBtn = new Button(Text = "Exit", Width = 150, Height = 40, Location = Point(900, 500), BackColor = Color.DarkRed)

    // Initialize components
    do
        // Show Books button click event
        showBooksBtn.Click.Add(fun _ ->
            let showBooksForm = new ShowBooksForm()
            showBooksForm.Show()
        )

        // Search button click event
        searchBtn.Click.Add(fun _ ->
            let searchText = searchArea.Text.Trim() // Get the text and trim any spaces
            if String.IsNullOrWhiteSpace(searchText) then
                // Display an alert if the search box is empty
                MessageBox.Show(
                    "The search field is required. Please enter the book name you want to search.", 
                    "Input Required", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                ) |> ignore
            else
                printfn "Search button clicked with text: %s" searchText // Debug print
                let searchForm = new SearchForm(searchText)
                searchForm.Show() |> ignore
        )

        // Exit button click event
        exitBtn.Click.Add(fun _ ->
            Application.Exit()
        )

        // Add Book button click event
        addBookBtn.Click.Add(fun _ ->
            let addBookForm = new AddBookForm()
            addBookForm.ShowDialog() |> ignore
        )

        // Borrow Book button click event
        borrowBookBtn.Click.Add(fun _ ->
            let borrowBookForm = new BorrowBookForm()
            borrowBookForm.ShowDialog() |> ignore
        )

        // Return Book button click event
        returnBookBtn.Click.Add(fun _ ->
            // Trigger cleanup for expired books
            cleanUpExpiredBooks()

            // Collect details of expired books for feedback
            let expiredBooks =
                BorrowedBooksMap
                |> Map.filter (fun _ book ->
                    match book.BorrowDate with
                    | Some borrowDate -> DateTime.Now > borrowDate.AddHours(1.0)
                    | None -> false
                )

            // Provide feedback to the user
            if expiredBooks.IsEmpty then
                MessageBox.Show(
                    "No books were expired at this time.",
                    "Return Books",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                ) |> ignore
            else
                let titles = expiredBooks |> Map.toList |> List.map fst |> String.concat ", "
                MessageBox.Show(
                    $"The following books are now available: {titles}",
                    "Return Books",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                ) |> ignore
        )

        // Form setup
        this.Text <- "Home Page"
        this.Height <- 600
        this.Width <- 1100
        this.BackColor <- Color.Honeydew

        // Add controls to the form
        this.Controls.Add(searchLabel)
        this.Controls.Add(searchArea)
        this.Controls.Add(searchBtn)
        this.Controls.Add(addBookBtn)
        this.Controls.Add(returnBookBtn)
        this.Controls.Add(showBooksBtn)
        this.Controls.Add(borrowBookBtn)
        this.Controls.Add(exitBtn)
