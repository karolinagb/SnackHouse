﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackHouse.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories" +
                "(CategoryName,Description) VALUES('Normal','Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categories" +
                "(CategoryName,Description) VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

            migrationBuilder.Sql("INSERT INTO Snacks" +
                "(CategoryId,SmallDescription,LongDescription,InStock,ImgThumbnailUrl,ImgUrl,IsPreferSnack,Name,Price) " +
                "VALUES(1,'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',1, 'cheesesalada1.jpg','cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Snacks" +
                "(CategoryId,SmallDescription,LongDescription,InStock,ImgThumbnailUrl,ImgUrl,IsPreferSnack,Name,Price) " +
                "VALUES(1,'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'mistoquente4.jpg','mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Snacks" +
                "(CategoryId,SmallDescription,LongDescription,InStock,ImgThumbnailUrl,ImgUrl,IsPreferSnack,Name,Price) " +
                "VALUES(1,'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'cheeseburger1.jpg','cheeseburger1.jpg',1,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Snacks" +
                "(CategoryId,SmallDescription,LongDescription,InStock,ImgThumbnailUrl,ImgUrl,IsPreferSnack,Name,Price) " +
                "VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'lanchenatural.jpg','lanchenatural.jpg',0,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
