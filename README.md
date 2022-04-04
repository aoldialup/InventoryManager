# InventoryManager

Here is an explanation and example of the files you need in order to operate this program and how they work.

`inventory_example.txt`
```
Pants,PantsBrandname_0,50.15,000000000000,Cotton,32
Book,BookName_1,12.92,000000000001,Lit-RPG,Audiobook,1962,AuthorName_1,PublisherName_1
Game,GameName_2,77.37,000000000002,RPG,Nintendo,2000,M,100
Movie,MovieName_4,29.97,000000000004,Action,Blu-Ray,1996,DirectorName_4,R,240
Book,BookName_5,18.82,000000000005,Adventure,Audiobook,1695,AuthorName_5,PublisherName_5
Movie,MovieName_6,11.72,000000000006,Adventure,Blu-Ray,1989,DirectorName_6,PG,113
Movie,MovieName_7,23.61,000000000007,Action,DVD,1943,DirectorName_7,PG-13,235
Pants,PantsBrandname_8,58.15,000000000008,Canvas,31
Pants,PantsBrandname_9,23.89,000000000009,Canvas,48
Game,GameName_10,39.22,000000000010,Adventure,Microsoft,2017,M,43
Dress,DressBrandname_11,61.47,000000000011,Spandex,Sun Dress,M
Movie,MovieName_12,29.76,000000000012,Adventure,DVD,1975,DirectorName_12,PG-13,126
Book,BookName_13,30.74,000000000013,Adventure,Audiobook,1601,AuthorName_13,PublisherName_13
Dress,DressBrandname_14,64.06,000000000014,Spandex,Formal Gown,XL
```

This file determines which items you would like your inventory to start with.
To understand more about each type of item, you can search for its class. For example, `Movie` for Movie and `Pants` for Pants.
This file will be overriden by the program each time an action that mutates the inventory is performed. 

`actions_example.txt`
```
Display2:Movie
Display2:Game
Display2:Top
Add:Movie,The Matrix,6.99,076950450479,Action,DVD,1999,Wachowski Brothers,R,136
Add:Game,Halo Reach,59.99,614141007349,FPS,Microsoft,2010,M,91
Add:Top,GAP,19.99,567890543312,Cotton,T-Shirt,XL
SortByName
Display2:Movie
Display2:Game
Display2:Top
FindBarcode:076950450479:Modify:18.95
FindBarcode:076950450479:Display
FindName:Halo Reach:Modify:0:59.99
SortByCost
Display2:Game
Display2:Book
FindBarcode:567890543312:Delete
Display2:Top
```

This file tells the program what to do with your inventory. Any action that modifies the inventory will result in the `inventory_example.txt` being overriden with new inventory data.

`result_example.txt`
```
Type: Movie
Name: MovieName_4
Cost: 29.97
Barcode: 000000000004
Genre: Action
Platform: Blu-Ray
Release Year: 1996
Director: DirectorName_4
MPAA Rating: R
Duration: 240

Type: Movie
Name: MovieName_6
Cost: 11.72
Barcode: 000000000006
Genre: Adventure
Platform: Blu-Ray
Release Year: 1989
Director: DirectorName_6
MPAA Rating: PG
Duration: 113

Type: Game
Name: GameName_2
Cost: 77.37
Barcode: 000000000002
Genre: RPG
Platform: Nintendo
Release Year: 2000
Rating: M
Score: 100

Type: Game
Name: GameName_10
Cost: 39.22
Barcode: 000000000010
Genre: Adventure
Platform: Microsoft
Release Year: 2017
Rating: M
Score: 43

No products of type Top found.

Type: Movie
Name: MovieName_12
Cost: 29.76
Barcode: 000000000012
Genre: Adventure
Platform: DVD
Release Year: 1975
Director: DirectorName_12
MPAA Rating: PG-13
Duration: 126

Type: Movie
Name: MovieName_4
Cost: 29.97
Barcode: 000000000004
Genre: Action
Platform: Blu-Ray
Release Year: 1996
Director: DirectorName_4
MPAA Rating: R
Duration: 240

Type: Game
Name: GameName_10
Cost: 39.22
Barcode: 000000000010
Genre: Adventure
Platform: Microsoft
Release Year: 2017
Rating: M
Score: 43

Type: Game
Name: GameName_2
Cost: 77.37
Barcode: 000000000002
Genre: RPG
Platform: Nintendo
Release Year: 2000
Rating: M
Score: 100

Type: Top
Name: GAP
Cost: 19.99
Barcode: 567890543312
Material: Cotton
Top Style: T-Shirt
Size: XL

Type: Movie
Name: The Matrix
Cost: 18.95
Barcode: 076950450479
Genre: Action
Platform: DVD
Release Year: 1999
Director: Wachowski Brothers
MPAA Rating: R
Duration: 136

Type: Game
Name: GameName_2
Cost: 77.37
Barcode: 000000000002
Genre: RPG
Platform: Nintendo
Release Year: 2000
Rating: M
Score: 100

Type: Game
Name: Halo Reach
Cost: 59.99
Barcode: 614141007349
Genre: FPS
Platform: Microsoft
Release Year: 2010
Rating: M
Score: 91

Type: Book
Name: BookName_13
Cost: 30.74
Barcode: 000000000013
Genre: Adventure
Platform: Audiobook
Release Year: 1601
Author: AuthorName_13
Publisher: PublisherName_13

Type: Book
Name: BookName_5
Cost: 18.82
Barcode: 000000000005
Genre: Adventure
Platform: Audiobook
Release Year: 1695
Author: AuthorName_5
Publisher: PublisherName_5

No products of type Top found.
```

This result file is only written to when certain commands that output to it are used (e.g. `Display2`). You can look further into the workings of commands by heading to the `Inventory` class.
