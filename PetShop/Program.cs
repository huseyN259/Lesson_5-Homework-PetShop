using System;
enum Gender { Male, Female };

class Animal
{
	public string? Nickname { get; set; }
	public int Age { get; set; }
	public Gender Gender { get; set; }
	public int Energy { get; set; }
	public double Price { get; set; }
	public int MealQuantity { get; set; }

	public Animal(string nickname, int age, Gender gender, int energy, double price, int mealQuantity)
	{
		Nickname = nickname;
		Age = age;
		Gender = gender;
		Energy = energy;
		Price = price;
		MealQuantity = mealQuantity;
	}

	virtual public void Eat() { }
	virtual public void Play() { }
	virtual public void Sleep() { }

	public override string ToString()
	{
		Console.WriteLine();
		return $@"Nickname : {Nickname}
Age : {Age}
Gender : {Gender}
Energy : {Energy}
Price : {Price}
Meal Quantity : {MealQuantity}";
	}
}

class Cat : Animal
{
	public string? Color { get; set; }

	public Cat(string Color, string nickname, int age, Gender gender, int energy, double price, int mealQuantity)
		: base(nickname, age, gender, energy, price, mealQuantity)
	{
		this.Color = Color;
	}

	public override void Eat()
	{
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine("\nCat is eating...");
		System.Threading.Thread.Sleep(1500);
		Console.WriteLine("\nCat is finished eating !");

		base.Energy += 10;
		if (base.Energy > 100)
			base.Energy = 100;
		Console.WriteLine($"Energy of Cat is {base.Energy}");

		base.Price += 50;
		Console.WriteLine($"Price of Cat is {base.Price}");
	}

	public override void Play()
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("\nCat is playing...");
		System.Threading.Thread.Sleep(2000);
		Console.WriteLine("\nCat is finished playing !");

		base.Energy -= 10;
		if (base.Energy < 0)
		{
			Console.WriteLine("Energy is over !");
			Sleep();
		}
		else
			Console.WriteLine($"Energy of Cat is {base.Energy}");
	}

	public override void Sleep()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nCat is sleeping...");
		System.Threading.Thread.Sleep(3000);
		Console.WriteLine("\nCat woke up !");

		base.Energy += 50;
		if (base.Energy > 100)
			base.Energy = 100;
		Console.WriteLine($"Energy of Cat is {base.Energy}");
	}

	public override string ToString()
	{
		return $@"{base.ToString()}
Color : {Color}";
	}
}

class Dog : Animal
{
	public string? Color { get; set; }

	public Dog(string Color, string nickname, int age, Gender gender, int energy, double price, int mealquantity)
		: base(nickname, age, gender, energy, price, mealquantity)
	{
		this.Color = Color;
	}

	public override void Eat()
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("\nDog is eating...");
		System.Threading.Thread.Sleep(1500);
		Console.WriteLine("\nDog is finished eating !");

		base.Energy += 20;
		if (base.Energy > 100)
			base.Energy = 100;
		Console.WriteLine($"Energy of Dog is {base.Energy}");

		base.Price += 70;
		Console.WriteLine($"Price of Dog is {base.Price}");
	}

	public override void Play()
	{
		Console.ForegroundColor = ConsoleColor.DarkMagenta;
		Console.WriteLine("\nDog is playing...");
		System.Threading.Thread.Sleep(2000);
		Console.WriteLine("\nDog is finished playing !");

		base.Energy -= 5;
		if (base.Energy < 0)
		{
			Console.WriteLine("Energy is over !");
			Sleep();
		}
		else
			Console.WriteLine($"Energy of Dog is {base.Energy}");
	}

	public override void Sleep()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nDog is sleeping...");
		System.Threading.Thread.Sleep(3000);
		Console.WriteLine("\nDog woke up !");

		base.Energy += 70;
		if (base.Energy > 100)
			base.Energy = 100;
		Console.WriteLine($"Energy of Dog is {base.Energy}");
	}

	public override string ToString()
	{
		return $@"{base.ToString()}
Color : { Color }";
	}
}

class Program
{
	static public Animal[] RemoveByNickname(Animal[] animals, string nickname)
	{
		Animal[] newAnimal = new Animal[animals.Length - 1];

		for (int i = 0, j = 0; i < animals.Length; i++)
		{
			if (animals[i].Nickname == nickname)
				continue;
			else
				newAnimal[j++] = animals[i];
		}

		return newAnimal;
	}
	static void Main()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		string enter = "Welcome to PET SHOP";
		Console.WriteLine(enter.PadLeft(70));

		Animal[] animals =
		{
			new Cat("Black", "Mimi", 1, Gender.Female, 35, 120, 300),
			new Dog("Grey", "Rex", 2, Gender.Male, 43, 110, 550)
		};

		/*foreach (Animal animal in animals)
			Console.WriteLine(animal);

		animals = RemoveByNickname(animals, "Rex");

		Console.Write("\n=== After ===");
		foreach (Animal animal in animals)
			Console.WriteLine(animal);*/

		Console.WriteLine("Looking for CATS -> 1\nLooking for DOGS -> 2\n");

		Console.Write("Enter your choice : ");
		char ch;
		char.TryParse(Console.ReadLine(), out ch);

		Console.Clear();

		switch (ch)
		{
			case '1':
				// Cat's works
				animals[0].Play();
				Console.WriteLine(animals[0].Energy);
				animals[0].Sleep();
				Console.WriteLine(animals[0].Energy);
				break;
			case '2':
				// Dog's works
				animals[1].Eat();
				animals[1].Play();
				Console.WriteLine(animals[1].Energy);
				animals[1].Sleep();
				Console.WriteLine(animals[1].Energy);
				break;
			default:
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Wrong input !");
				break;
		}
	}
}