--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2024-11-26 10:00:57

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 236 (class 1259 OID 16478)
-- Name: Comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Comment" (
    "CommentId" integer NOT NULL,
    "TaskId" integer,
    "UserId" integer,
    "Content" text,
    "CreatedAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public."Comment" OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16477)
-- Name: Comment_CommentId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Comment_CommentId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Comment_CommentId_seq" OWNER TO postgres;

--
-- TOC entry 4953 (class 0 OID 0)
-- Dependencies: 235
-- Name: Comment_CommentId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Comment_CommentId_seq" OWNED BY public."Comment"."CommentId";


--
-- TOC entry 224 (class 1259 OID 16424)
-- Name: Menu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "MenuName" character varying(255) NOT NULL,
    "MenuUrl" character varying(255),
    "ParentMenuId" integer,
    "IsVisible" boolean NOT NULL
);


ALTER TABLE public."Menu" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16423)
-- Name: Menu_MenuId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Menu_MenuId_seq" OWNER TO postgres;

--
-- TOC entry 4954 (class 0 OID 0)
-- Dependencies: 223
-- Name: Menu_MenuId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";


--
-- TOC entry 222 (class 1259 OID 16417)
-- Name: Permission; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Permission" (
    "PermissionId" integer NOT NULL,
    "TableName" character varying(255) NOT NULL,
    "CanView" boolean NOT NULL,
    "CanAdd" boolean NOT NULL,
    "CanEdit" boolean NOT NULL,
    "CanDelete" boolean NOT NULL
);


ALTER TABLE public."Permission" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16416)
-- Name: Permission_PermissionId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Permission_PermissionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Permission_PermissionId_seq" OWNER TO postgres;

--
-- TOC entry 4955 (class 0 OID 0)
-- Dependencies: 221
-- Name: Permission_PermissionId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Permission_PermissionId_seq" OWNED BY public."Permission"."PermissionId";


--
-- TOC entry 228 (class 1259 OID 16440)
-- Name: Project; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Project" (
    "ProjectId" integer NOT NULL,
    "ProjectName" character varying(255) NOT NULL,
    "Description" text,
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone,
    "Status" integer NOT NULL,
    "CreatedBy" integer,
    "CreatedAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public."Project" OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16470)
-- Name: ProjectUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProjectUser" (
    "ProjectUserId" integer NOT NULL,
    "ProjectId" integer,
    "UserId" integer,
    "Role" character varying(50),
    "JoinedAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public."ProjectUser" OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 16495)
-- Name: ProjectUserInvite; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProjectUserInvite" (
    "InviteId" integer NOT NULL,
    "ProjectId" integer,
    "UserId" integer,
    "Status" integer,
    "SentAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    "AcceptedAt" timestamp without time zone
);


ALTER TABLE public."ProjectUserInvite" OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16494)
-- Name: ProjectUserInvite_InviteId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ProjectUserInvite_InviteId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ProjectUserInvite_InviteId_seq" OWNER TO postgres;

--
-- TOC entry 4956 (class 0 OID 0)
-- Dependencies: 237
-- Name: ProjectUserInvite_InviteId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ProjectUserInvite_InviteId_seq" OWNED BY public."ProjectUserInvite"."InviteId";


--
-- TOC entry 233 (class 1259 OID 16469)
-- Name: ProjectUser_ProjectUserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ProjectUser_ProjectUserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ProjectUser_ProjectUserId_seq" OWNER TO postgres;

--
-- TOC entry 4957 (class 0 OID 0)
-- Dependencies: 233
-- Name: ProjectUser_ProjectUserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ProjectUser_ProjectUserId_seq" OWNED BY public."ProjectUser"."ProjectUserId";


--
-- TOC entry 227 (class 1259 OID 16439)
-- Name: Project_ProjectId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Project_ProjectId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Project_ProjectId_seq" OWNER TO postgres;

--
-- TOC entry 4958 (class 0 OID 0)
-- Dependencies: 227
-- Name: Project_ProjectId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Project_ProjectId_seq" OWNED BY public."Project"."ProjectId";


--
-- TOC entry 232 (class 1259 OID 16460)
-- Name: Request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "UserId" integer,
    "ProjectId" integer,
    "RequestType" character varying(100),
    "Description" text,
    "Status" integer NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" timestamp without time zone
);


ALTER TABLE public."Request" OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16459)
-- Name: Request_RequestId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Request_RequestId_seq" OWNER TO postgres;

--
-- TOC entry 4959 (class 0 OID 0)
-- Dependencies: 231
-- Name: Request_RequestId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";


--
-- TOC entry 220 (class 1259 OID 16408)
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "RoleName" character varying(255) NOT NULL,
    "Description" text
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16433)
-- Name: RoleMenuAccess; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleMenuAccess" (
    "AccessId" integer NOT NULL,
    "MenuId" integer,
    "CanAccess" boolean NOT NULL,
    "RoleId" integer
);


ALTER TABLE public."RoleMenuAccess" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16432)
-- Name: RoleMenuAccess_AccessId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RoleMenuAccess_AccessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RoleMenuAccess_AccessId_seq" OWNER TO postgres;

--
-- TOC entry 4960 (class 0 OID 0)
-- Dependencies: 225
-- Name: RoleMenuAccess_AccessId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RoleMenuAccess_AccessId_seq" OWNED BY public."RoleMenuAccess"."AccessId";


--
-- TOC entry 239 (class 1259 OID 16503)
-- Name: RolePermissions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RolePermissions" (
    "Id" integer NOT NULL,
    "RoleId" integer,
    "PermissionId" integer
);


ALTER TABLE public."RolePermissions" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16407)
-- Name: Role_RoleId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Role_RoleId_seq" OWNER TO postgres;

--
-- TOC entry 4961 (class 0 OID 0)
-- Dependencies: 219
-- Name: Role_RoleId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";


--
-- TOC entry 230 (class 1259 OID 16450)
-- Name: Task; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Task" (
    "TaskId" integer NOT NULL,
    "ProjectId" integer,
    "AssignedTo" integer,
    "TaskName" character varying(255) NOT NULL,
    "Description" text,
    "DueDate" timestamp without time zone,
    "Status" integer NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" timestamp without time zone
);


ALTER TABLE public."Task" OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16449)
-- Name: Task_TaskId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Task_TaskId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Task_TaskId_seq" OWNER TO postgres;

--
-- TOC entry 4962 (class 0 OID 0)
-- Dependencies: 229
-- Name: Task_TaskId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Task_TaskId_seq" OWNED BY public."Task"."TaskId";


--
-- TOC entry 218 (class 1259 OID 16390)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "UserId" integer NOT NULL,
    "Username" character varying(50) NOT NULL,
    "Password" character varying(255) NOT NULL,
    "FullName" character varying(255),
    "IsDel" boolean
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16389)
-- Name: User_UserId_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."User_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."User_UserId_seq" OWNER TO postgres;

--
-- TOC entry 4963 (class 0 OID 0)
-- Dependencies: 217
-- Name: User_UserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."User_UserId_seq" OWNED BY public."Users"."UserId";


--
-- TOC entry 4750 (class 2604 OID 16481)
-- Name: Comment CommentId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comment" ALTER COLUMN "CommentId" SET DEFAULT nextval('public."Comment_CommentId_seq"'::regclass);


--
-- TOC entry 4740 (class 2604 OID 16427)
-- Name: Menu MenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);


--
-- TOC entry 4739 (class 2604 OID 16420)
-- Name: Permission PermissionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Permission" ALTER COLUMN "PermissionId" SET DEFAULT nextval('public."Permission_PermissionId_seq"'::regclass);


--
-- TOC entry 4742 (class 2604 OID 16443)
-- Name: Project ProjectId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Project" ALTER COLUMN "ProjectId" SET DEFAULT nextval('public."Project_ProjectId_seq"'::regclass);


--
-- TOC entry 4748 (class 2604 OID 16473)
-- Name: ProjectUser ProjectUserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUser" ALTER COLUMN "ProjectUserId" SET DEFAULT nextval('public."ProjectUser_ProjectUserId_seq"'::regclass);


--
-- TOC entry 4752 (class 2604 OID 16498)
-- Name: ProjectUserInvite InviteId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUserInvite" ALTER COLUMN "InviteId" SET DEFAULT nextval('public."ProjectUserInvite_InviteId_seq"'::regclass);


--
-- TOC entry 4746 (class 2604 OID 16463)
-- Name: Request RequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);


--
-- TOC entry 4738 (class 2604 OID 16411)
-- Name: Role RoleId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);


--
-- TOC entry 4741 (class 2604 OID 16436)
-- Name: RoleMenuAccess AccessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenuAccess" ALTER COLUMN "AccessId" SET DEFAULT nextval('public."RoleMenuAccess_AccessId_seq"'::regclass);


--
-- TOC entry 4744 (class 2604 OID 16453)
-- Name: Task TaskId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Task" ALTER COLUMN "TaskId" SET DEFAULT nextval('public."Task_TaskId_seq"'::regclass);


--
-- TOC entry 4737 (class 2604 OID 16393)
-- Name: Users UserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "UserId" SET DEFAULT nextval('public."User_UserId_seq"'::regclass);


--
-- TOC entry 4944 (class 0 OID 16478)
-- Dependencies: 236
-- Data for Name: Comment; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4932 (class 0 OID 16424)
-- Dependencies: 224
-- Data for Name: Menu; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Menu" VALUES (1, 'Project', '/project', NULL, true);
INSERT INTO public."Menu" VALUES (2, 'Task', '/task', NULL, true);
INSERT INTO public."Menu" VALUES (3, 'Dashboard', '/dashboard', NULL, true);


--
-- TOC entry 4930 (class 0 OID 16417)
-- Dependencies: 222
-- Data for Name: Permission; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Permission" VALUES (1, 'Project', true, true, true, true);
INSERT INTO public."Permission" VALUES (2, 'Task', true, true, true, true);
INSERT INTO public."Permission" VALUES (3, 'Menu', false, false, false, false);


--
-- TOC entry 4936 (class 0 OID 16440)
-- Dependencies: 228
-- Data for Name: Project; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4942 (class 0 OID 16470)
-- Dependencies: 234
-- Data for Name: ProjectUser; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4946 (class 0 OID 16495)
-- Dependencies: 238
-- Data for Name: ProjectUserInvite; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4940 (class 0 OID 16460)
-- Dependencies: 232
-- Data for Name: Request; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4928 (class 0 OID 16408)
-- Dependencies: 220
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Role" VALUES (1, 'Admin', 'Quản trị viên');
INSERT INTO public."Role" VALUES (2, 'Manager', 'Người quản lý');
INSERT INTO public."Role" VALUES (3, 'Customers', 'Khách hàng');


--
-- TOC entry 4934 (class 0 OID 16433)
-- Dependencies: 226
-- Data for Name: RoleMenuAccess; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RoleMenuAccess" VALUES (1, 1, true, 1);
INSERT INTO public."RoleMenuAccess" VALUES (2, 2, true, 1);
INSERT INTO public."RoleMenuAccess" VALUES (3, 1, true, 2);
INSERT INTO public."RoleMenuAccess" VALUES (4, 1, true, 3);
INSERT INTO public."RoleMenuAccess" VALUES (5, 2, false, 3);


--
-- TOC entry 4947 (class 0 OID 16503)
-- Dependencies: 239
-- Data for Name: RolePermissions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RolePermissions" VALUES (1, 1, 1);
INSERT INTO public."RolePermissions" VALUES (2, 1, 2);
INSERT INTO public."RolePermissions" VALUES (3, 2, 1);
INSERT INTO public."RolePermissions" VALUES (4, 2, 2);
INSERT INTO public."RolePermissions" VALUES (5, 3, 1);
INSERT INTO public."RolePermissions" VALUES (6, 3, 2);


--
-- TOC entry 4938 (class 0 OID 16450)
-- Dependencies: 230
-- Data for Name: Task; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4926 (class 0 OID 16390)
-- Dependencies: 218
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" VALUES (1, 'longlt', 'longlt', 'Lê Thành Long', false);


--
-- TOC entry 4964 (class 0 OID 0)
-- Dependencies: 235
-- Name: Comment_CommentId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Comment_CommentId_seq"', 1, false);


--
-- TOC entry 4965 (class 0 OID 0)
-- Dependencies: 223
-- Name: Menu_MenuId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 3, true);


--
-- TOC entry 4966 (class 0 OID 0)
-- Dependencies: 221
-- Name: Permission_PermissionId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Permission_PermissionId_seq"', 3, true);


--
-- TOC entry 4967 (class 0 OID 0)
-- Dependencies: 237
-- Name: ProjectUserInvite_InviteId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ProjectUserInvite_InviteId_seq"', 1, false);


--
-- TOC entry 4968 (class 0 OID 0)
-- Dependencies: 233
-- Name: ProjectUser_ProjectUserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ProjectUser_ProjectUserId_seq"', 1, false);


--
-- TOC entry 4969 (class 0 OID 0)
-- Dependencies: 227
-- Name: Project_ProjectId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Project_ProjectId_seq"', 1, false);


--
-- TOC entry 4970 (class 0 OID 0)
-- Dependencies: 231
-- Name: Request_RequestId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Request_RequestId_seq"', 1, false);


--
-- TOC entry 4971 (class 0 OID 0)
-- Dependencies: 225
-- Name: RoleMenuAccess_AccessId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RoleMenuAccess_AccessId_seq"', 5, true);


--
-- TOC entry 4972 (class 0 OID 0)
-- Dependencies: 219
-- Name: Role_RoleId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Role_RoleId_seq"', 6, true);


--
-- TOC entry 4973 (class 0 OID 0)
-- Dependencies: 229
-- Name: Task_TaskId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Task_TaskId_seq"', 1, false);


--
-- TOC entry 4974 (class 0 OID 0)
-- Dependencies: 217
-- Name: User_UserId_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_UserId_seq"', 1, true);


--
-- TOC entry 4775 (class 2606 OID 16486)
-- Name: Comment Comment_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comment"
    ADD CONSTRAINT "Comment_pkey" PRIMARY KEY ("CommentId");


--
-- TOC entry 4763 (class 2606 OID 16431)
-- Name: Menu Menu_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");


--
-- TOC entry 4761 (class 2606 OID 16422)
-- Name: Permission Permission_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Permission"
    ADD CONSTRAINT "Permission_pkey" PRIMARY KEY ("PermissionId");


--
-- TOC entry 4777 (class 2606 OID 16501)
-- Name: ProjectUserInvite ProjectUserInvite_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUserInvite"
    ADD CONSTRAINT "ProjectUserInvite_pkey" PRIMARY KEY ("InviteId");


--
-- TOC entry 4773 (class 2606 OID 16476)
-- Name: ProjectUser ProjectUser_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUser"
    ADD CONSTRAINT "ProjectUser_pkey" PRIMARY KEY ("ProjectUserId");


--
-- TOC entry 4767 (class 2606 OID 16448)
-- Name: Project Project_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Project"
    ADD CONSTRAINT "Project_pkey" PRIMARY KEY ("ProjectId");


--
-- TOC entry 4771 (class 2606 OID 16468)
-- Name: Request Request_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");


--
-- TOC entry 4765 (class 2606 OID 16438)
-- Name: RoleMenuAccess RoleMenuAccess_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenuAccess"
    ADD CONSTRAINT "RoleMenuAccess_pkey" PRIMARY KEY ("AccessId");


--
-- TOC entry 4779 (class 2606 OID 16507)
-- Name: RolePermissions RolePermissions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RolePermissions"
    ADD CONSTRAINT "RolePermissions_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4759 (class 2606 OID 16415)
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");


--
-- TOC entry 4769 (class 2606 OID 16458)
-- Name: Task Task_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Task"
    ADD CONSTRAINT "Task_pkey" PRIMARY KEY ("TaskId");


--
-- TOC entry 4755 (class 2606 OID 16399)
-- Name: Users User_Username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "User_Username_key" UNIQUE ("Username");


--
-- TOC entry 4757 (class 2606 OID 16397)
-- Name: Users User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");


-- Completed on 2024-11-26 10:00:57

--
-- PostgreSQL database dump complete
--

