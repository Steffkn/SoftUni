package com.company;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;

public class _24BookLibrary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Library lib = new Library("Library");
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd.MM.yyyy");
        int n = scan.nextInt();
        scan.nextLine();

        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().split(" ");

            lib.addBook(new Book(
                    input[0],
                    input[1],
                    input[2],
                    LocalDate.parse(input[3], format),
                    input[4],
                    Double.parseDouble(input[5])
            ));
        }

        LinkedHashMap<String, Double> authors = new LinkedHashMap<>();

        for (Book book : lib.getBooks()) {
            if (!authors.containsKey(book.getAuthor())) {
                authors.put(book.getAuthor(), book.getPrice());
            } else {
                authors.put(book.getAuthor(), authors.get(book.getAuthor()) + book.getPrice());
            }
        }

        Comparator<Map.Entry<String, Double>> compareByPrice = Comparator.comparing(Map.Entry::getValue, Comparator.reverseOrder());
        Comparator<Map.Entry<String, Double>> compareByName = Comparator.comparing(Map.Entry::getKey);

        authors.entrySet()
                .stream()
                .sorted(compareByPrice.thenComparing(compareByName))
                .forEach((Map.Entry<String, Double> kvp) ->
                        System.out.printf("%s -> %.2f%n", kvp.getKey(), kvp.getValue())
                );
    }
}

class Library {
    private String name;
    private ArrayList<Book> books;

    public Library(String name) {
        this.name = name;
        books = new ArrayList<>();
    }

    public ArrayList<Book> getBooks() {
        return books;
    }

    public void addBook(Book book) {
        this.books.add(book);
    }
}

class Book {
    private String title;
    private String author;
    private String publisher;
    private LocalDate releaseDate;
    private String ISBN;
    private double price;

    public Book(String title, String author, String publisher, LocalDate releaseDate, String ISBN, double price) {
        this.title = title;
        this.author = author;
        this.publisher = publisher;
        this.releaseDate = releaseDate;
        this.ISBN = ISBN;
        this.price = price;
    }

    public String getTitle() {
        return title;
    }

    public String getAuthor() {
        return author;
    }

    public double getPrice() {
        return price;
    }

    public LocalDate getReleaseDate() {
        return releaseDate;
    }

}