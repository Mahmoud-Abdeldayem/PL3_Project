module Forms.MainForm

open System.Windows.Forms
open System
open System.Drawing
open Forms.ShowBooksForm

type MainForm() as this = 
    inherit Form() 
    let searchBtn = new Button(Text = "Search" , Width = 150 , Height = 30 , BackColor = Drawing.Color.LightCoral,Location=Point(910, 25)) 
    let searchArea = new TextBox(Name="Search_Box" , Width=900, Height=30,Multiline=true,Location=Point(2, 25))
    let searchLabel = new Label(Text="Search a book :" , Location=Point(0, 0)) 
    let addBookBtn = new Button(
        Text="Add Book" ,
        Width = 400 ,
        Height = 100 ,
        Location = Point(10 , 100) ,
        Font = new Font("" , 20f),
        BackColor = Color.MediumAquamarine 
    )
    let returnBookBtn = new Button(
        Text="Return Book" ,
        Width = 400 ,
        Height = 100 ,
        Location = Point(670 , 100) ,
        Font = new Font("" , 20f),
        BackColor = Color.MediumAquamarine 
    )

    let showBooksBtn = new Button(
        Text="Show Books" ,
        Width = 400 ,
        Height = 100 ,
        Location = Point(10 , 250) ,
        Font = new Font("" , 20f),
        BackColor = Color.MediumAquamarine 
    )

    let borrowBookBtn = new Button(
        Text="Borrow Book" ,
        Width = 400 ,
        Height = 100 ,
        Location = Point(670 , 250) ,
        Font = new Font("" , 20f),
        BackColor = Color.MediumAquamarine 
    )

    let exitBtn = new Button(
        Text="Exit" ,
        Width = 150 ,
        Height = 40 ,
        Location = Point(900 , 500) ,
        BackColor = Color.DarkRed 
    )

    
    // Initialize components

    do 
        ///this.Icon <- new Icon("BookIcon.ico")  
        showBooksBtn.Click.Add(fun _ -> 
            let showBooksForm = new ShowBooksForm()
            showBooksForm.Show()
        )

        exitBtn.Click.Add(fun _ -> 
            Application.Exit()
        )

        this.Text <- "Home Page" 
        this.Height <- 600
        this.Width <- 1100 
        this.BackColor <- Color.Honeydew
        this.Controls.Add(searchLabel)
        this.Controls.Add(searchArea)
        this.Controls.Add(searchBtn) 
        this.Controls.Add(addBookBtn)
        this.Controls.Add(returnBookBtn)        
        this.Controls.Add(showBooksBtn)
        this.Controls.Add(borrowBookBtn) 
        this.Controls.Add(exitBtn)