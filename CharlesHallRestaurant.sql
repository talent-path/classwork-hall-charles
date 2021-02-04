--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.1

-- Started on 2021-02-03 18:01:46 EST

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Restaurant";
--
-- TOC entry 3344 (class 1262 OID 16429)
-- Name: Restaurant; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Restaurant" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'C';


ALTER DATABASE "Restaurant" OWNER TO "postgres";

\connect "Restaurant"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = "heap";

--
-- TOC entry 205 (class 1259 OID 16448)
-- Name: Dishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Dishes" (
    "dishId" integer NOT NULL,
    "dishName" character varying(50) NOT NULL
);


ALTER TABLE "public"."Dishes" OWNER TO "postgres";

--
-- TOC entry 204 (class 1259 OID 16446)
-- Name: Dishes_dishId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Dishes_dishId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Dishes_dishId_seq" OWNER TO "postgres";

--
-- TOC entry 3345 (class 0 OID 0)
-- Dependencies: 204
-- Name: Dishes_dishId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Dishes_dishId_seq" OWNED BY "public"."Dishes"."dishId";


--
-- TOC entry 201 (class 1259 OID 16432)
-- Name: Ingredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Ingredients" (
    "ingredientId" integer NOT NULL,
    "ingredientName" character varying(50) NOT NULL,
    "stock" numeric(20,0),
    "isOrganic" boolean
);


ALTER TABLE "public"."Ingredients" OWNER TO "postgres";

--
-- TOC entry 200 (class 1259 OID 16430)
-- Name: Ingredients_ingredientId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Ingredients_ingredientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Ingredients_ingredientId_seq" OWNER TO "postgres";

--
-- TOC entry 3346 (class 0 OID 0)
-- Dependencies: 200
-- Name: Ingredients_ingredientId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Ingredients_ingredientId_seq" OWNED BY "public"."Ingredients"."ingredientId";


--
-- TOC entry 215 (class 1259 OID 16517)
-- Name: MenuDishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."MenuDishes" (
    "menuId" integer NOT NULL,
    "dishId" integer NOT NULL,
    "price" numeric(5,0) NOT NULL
);


ALTER TABLE "public"."MenuDishes" OWNER TO "postgres";

--
-- TOC entry 203 (class 1259 OID 16440)
-- Name: Menus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Menus" (
    "menuId" integer NOT NULL,
    "menuName" character varying(50) NOT NULL
);


ALTER TABLE "public"."Menus" OWNER TO "postgres";

--
-- TOC entry 202 (class 1259 OID 16438)
-- Name: Menus_menuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Menus_menuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Menus_menuId_seq" OWNER TO "postgres";

--
-- TOC entry 3347 (class 0 OID 0)
-- Dependencies: 202
-- Name: Menus_menuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Menus_menuId_seq" OWNED BY "public"."Menus"."menuId";


--
-- TOC entry 217 (class 1259 OID 16547)
-- Name: OrderDishes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."OrderDishes" (
    "orderId" integer NOT NULL,
    "dishId" integer NOT NULL,
    "menuId" integer NOT NULL,
    "quantity" numeric(50,0) NOT NULL
);


ALTER TABLE "public"."OrderDishes" OWNER TO "postgres";

--
-- TOC entry 213 (class 1259 OID 16488)
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Orders" (
    "orderId" integer NOT NULL,
    "tableId" integer NOT NULL
);


ALTER TABLE "public"."Orders" OWNER TO "postgres";

--
-- TOC entry 212 (class 1259 OID 16486)
-- Name: Orders_orderId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Orders_orderId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Orders_orderId_seq" OWNER TO "postgres";

--
-- TOC entry 3348 (class 0 OID 0)
-- Dependencies: 212
-- Name: Orders_orderId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Orders_orderId_seq" OWNED BY "public"."Orders"."orderId";


--
-- TOC entry 214 (class 1259 OID 16499)
-- Name: RecipeIngredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."RecipeIngredients" (
    "recipeId" integer NOT NULL,
    "ingredientId" integer NOT NULL,
    "quantity" numeric NOT NULL,
    "unit" character varying(50) NOT NULL
);


ALTER TABLE "public"."RecipeIngredients" OWNER TO "postgres";

--
-- TOC entry 211 (class 1259 OID 16472)
-- Name: Recipes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Recipes" (
    "recipeId" integer NOT NULL,
    "dishId" integer NOT NULL,
    "recipeName" character varying(50) NOT NULL,
    "instructions" "text" NOT NULL
);


ALTER TABLE "public"."Recipes" OWNER TO "postgres";

--
-- TOC entry 210 (class 1259 OID 16470)
-- Name: Recipes_recipeId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Recipes_recipeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Recipes_recipeId_seq" OWNER TO "postgres";

--
-- TOC entry 3349 (class 0 OID 0)
-- Dependencies: 210
-- Name: Recipes_recipeId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Recipes_recipeId_seq" OWNED BY "public"."Recipes"."recipeId";


--
-- TOC entry 216 (class 1259 OID 16532)
-- Name: SupplierIngredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."SupplierIngredients" (
    "supplierId" integer NOT NULL,
    "ingredientId" integer NOT NULL,
    "qtyAvailable" numeric(50,0),
    "units" character varying(50),
    "unitCost" numeric(50,0) NOT NULL
);


ALTER TABLE "public"."SupplierIngredients" OWNER TO "postgres";

--
-- TOC entry 207 (class 1259 OID 16456)
-- Name: Suppliers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Suppliers" (
    "supplierId" integer NOT NULL,
    "supplierName" character varying(50) NOT NULL
);


ALTER TABLE "public"."Suppliers" OWNER TO "postgres";

--
-- TOC entry 206 (class 1259 OID 16454)
-- Name: Suppliers_supplierId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Suppliers_supplierId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Suppliers_supplierId_seq" OWNER TO "postgres";

--
-- TOC entry 3350 (class 0 OID 0)
-- Dependencies: 206
-- Name: Suppliers_supplierId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Suppliers_supplierId_seq" OWNED BY "public"."Suppliers"."supplierId";


--
-- TOC entry 209 (class 1259 OID 16464)
-- Name: Tabletops; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "public"."Tabletops" (
    "tableId" integer NOT NULL,
    "seatCount" smallint
);


ALTER TABLE "public"."Tabletops" OWNER TO "postgres";

--
-- TOC entry 208 (class 1259 OID 16462)
-- Name: Tabletops_tableId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "public"."Tabletops_tableId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "public"."Tabletops_tableId_seq" OWNER TO "postgres";

--
-- TOC entry 3351 (class 0 OID 0)
-- Dependencies: 208
-- Name: Tabletops_tableId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "public"."Tabletops_tableId_seq" OWNED BY "public"."Tabletops"."tableId";


--
-- TOC entry 3171 (class 2604 OID 16451)
-- Name: Dishes dishId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Dishes" ALTER COLUMN "dishId" SET DEFAULT "nextval"('"public"."Dishes_dishId_seq"'::"regclass");


--
-- TOC entry 3169 (class 2604 OID 16435)
-- Name: Ingredients ingredientId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Ingredients" ALTER COLUMN "ingredientId" SET DEFAULT "nextval"('"public"."Ingredients_ingredientId_seq"'::"regclass");


--
-- TOC entry 3170 (class 2604 OID 16443)
-- Name: Menus menuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Menus" ALTER COLUMN "menuId" SET DEFAULT "nextval"('"public"."Menus_menuId_seq"'::"regclass");


--
-- TOC entry 3175 (class 2604 OID 16491)
-- Name: Orders orderId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders" ALTER COLUMN "orderId" SET DEFAULT "nextval"('"public"."Orders_orderId_seq"'::"regclass");


--
-- TOC entry 3174 (class 2604 OID 16475)
-- Name: Recipes recipeId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes" ALTER COLUMN "recipeId" SET DEFAULT "nextval"('"public"."Recipes_recipeId_seq"'::"regclass");


--
-- TOC entry 3172 (class 2604 OID 16459)
-- Name: Suppliers supplierId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Suppliers" ALTER COLUMN "supplierId" SET DEFAULT "nextval"('"public"."Suppliers_supplierId_seq"'::"regclass");


--
-- TOC entry 3173 (class 2604 OID 16467)
-- Name: Tabletops tableId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Tabletops" ALTER COLUMN "tableId" SET DEFAULT "nextval"('"public"."Tabletops_tableId_seq"'::"regclass");


--
-- TOC entry 3181 (class 2606 OID 16453)
-- Name: Dishes Dishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Dishes"
    ADD CONSTRAINT "Dishes_pkey" PRIMARY KEY ("dishId");


--
-- TOC entry 3177 (class 2606 OID 16437)
-- Name: Ingredients Ingredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Ingredients"
    ADD CONSTRAINT "Ingredients_pkey" PRIMARY KEY ("ingredientId");


--
-- TOC entry 3193 (class 2606 OID 16521)
-- Name: MenuDishes MenuDishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_pkey" PRIMARY KEY ("menuId", "dishId");


--
-- TOC entry 3179 (class 2606 OID 16445)
-- Name: Menus Menus_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Menus"
    ADD CONSTRAINT "Menus_pkey" PRIMARY KEY ("menuId");


--
-- TOC entry 3197 (class 2606 OID 16551)
-- Name: OrderDishes OrderDishes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_pkey" PRIMARY KEY ("orderId", "dishId", "menuId");


--
-- TOC entry 3189 (class 2606 OID 16493)
-- Name: Orders Orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders"
    ADD CONSTRAINT "Orders_pkey" PRIMARY KEY ("orderId");


--
-- TOC entry 3191 (class 2606 OID 16506)
-- Name: RecipeIngredients RecipeIngredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_pkey" PRIMARY KEY ("recipeId", "ingredientId");


--
-- TOC entry 3187 (class 2606 OID 16480)
-- Name: Recipes Recipes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes"
    ADD CONSTRAINT "Recipes_pkey" PRIMARY KEY ("recipeId");


--
-- TOC entry 3195 (class 2606 OID 16536)
-- Name: SupplierIngredients SupplierIngredients_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_pkey" PRIMARY KEY ("supplierId", "ingredientId");


--
-- TOC entry 3183 (class 2606 OID 16461)
-- Name: Suppliers Suppliers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Suppliers"
    ADD CONSTRAINT "Suppliers_pkey" PRIMARY KEY ("supplierId");


--
-- TOC entry 3185 (class 2606 OID 16469)
-- Name: Tabletops Tabletops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Tabletops"
    ADD CONSTRAINT "Tabletops_pkey" PRIMARY KEY ("tableId");


--
-- TOC entry 3203 (class 2606 OID 16527)
-- Name: MenuDishes MenuDishes_dishId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_dishId_fkey" FOREIGN KEY ("dishId") REFERENCES "public"."Dishes"("dishId");


--
-- TOC entry 3202 (class 2606 OID 16522)
-- Name: MenuDishes MenuDishes_menuId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."MenuDishes"
    ADD CONSTRAINT "MenuDishes_menuId_fkey" FOREIGN KEY ("menuId") REFERENCES "public"."Menus"("menuId");


--
-- TOC entry 3207 (class 2606 OID 16557)
-- Name: OrderDishes OrderDishes_dishId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_dishId_fkey" FOREIGN KEY ("dishId") REFERENCES "public"."Dishes"("dishId");


--
-- TOC entry 3208 (class 2606 OID 16562)
-- Name: OrderDishes OrderDishes_menuId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_menuId_fkey" FOREIGN KEY ("menuId") REFERENCES "public"."Menus"("menuId");


--
-- TOC entry 3206 (class 2606 OID 16552)
-- Name: OrderDishes OrderDishes_orderId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."OrderDishes"
    ADD CONSTRAINT "OrderDishes_orderId_fkey" FOREIGN KEY ("orderId") REFERENCES "public"."Orders"("orderId");


--
-- TOC entry 3199 (class 2606 OID 16494)
-- Name: Orders Orders_tableId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Orders"
    ADD CONSTRAINT "Orders_tableId_fkey" FOREIGN KEY ("tableId") REFERENCES "public"."Tabletops"("tableId");


--
-- TOC entry 3201 (class 2606 OID 16512)
-- Name: RecipeIngredients RecipeIngredients_ingredientId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_ingredientId_fkey" FOREIGN KEY ("ingredientId") REFERENCES "public"."Ingredients"("ingredientId");


--
-- TOC entry 3200 (class 2606 OID 16507)
-- Name: RecipeIngredients RecipeIngredients_recipeId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."RecipeIngredients"
    ADD CONSTRAINT "RecipeIngredients_recipeId_fkey" FOREIGN KEY ("recipeId") REFERENCES "public"."Recipes"("recipeId");


--
-- TOC entry 3198 (class 2606 OID 16481)
-- Name: Recipes Recipes_dishId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."Recipes"
    ADD CONSTRAINT "Recipes_dishId_fkey" FOREIGN KEY ("dishId") REFERENCES "public"."Dishes"("dishId");


--
-- TOC entry 3205 (class 2606 OID 16542)
-- Name: SupplierIngredients SupplierIngredients_ingredientId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_ingredientId_fkey" FOREIGN KEY ("ingredientId") REFERENCES "public"."Ingredients"("ingredientId");


--
-- TOC entry 3204 (class 2606 OID 16537)
-- Name: SupplierIngredients SupplierIngredients_supplierId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "public"."SupplierIngredients"
    ADD CONSTRAINT "SupplierIngredients_supplierId_fkey" FOREIGN KEY ("supplierId") REFERENCES "public"."Suppliers"("supplierId");


-- Completed on 2021-02-03 18:01:46 EST

--
-- PostgreSQL database dump complete
--

