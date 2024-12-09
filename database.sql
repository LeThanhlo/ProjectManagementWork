--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2024-12-09 14:56:01

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'BIG5';
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
-- TOC entry 4959 (class 0 OID 0)
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
-- TOC entry 4960 (class 0 OID 0)
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
-- TOC entry 4961 (class 0 OID 0)
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
-- TOC entry 4962 (class 0 OID 0)
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
-- TOC entry 4963 (class 0 OID 0)
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
-- TOC entry 4964 (class 0 OID 0)
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
-- TOC entry 4965 (class 0 OID 0)
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
-- TOC entry 4966 (class 0 OID 0)
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
-- TOC entry 4967 (class 0 OID 0)
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
-- TOC entry 4968 (class 0 OID 0)
-- Dependencies: 229
-- Name: Task_TaskId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Task_TaskId_seq" OWNED BY public."Task"."TaskId";


--
-- TOC entry 240 (class 1259 OID 16508)
-- Name: UserRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserRole" (
    "Id" integer NOT NULL,
    "UserId" integer,
    "RoleId" bigint
);


ALTER TABLE public."UserRole" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16390)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "UserId" integer NOT NULL,
    "Username" character varying(50) NOT NULL,
    "Password" character varying(255) NOT NULL,
    "FullName" character varying(255),
    "IsDel" boolean,
    "Address" text,
    "Phone" text,
    "Email" text
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
-- TOC entry 4969 (class 0 OID 0)
-- Dependencies: 217
-- Name: User_UserId_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."User_UserId_seq" OWNED BY public."Users"."UserId";


--
-- TOC entry 4753 (class 2604 OID 16481)
-- Name: Comment CommentId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comment" ALTER COLUMN "CommentId" SET DEFAULT nextval('public."Comment_CommentId_seq"'::regclass);


--
-- TOC entry 4743 (class 2604 OID 16427)
-- Name: Menu MenuId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);


--
-- TOC entry 4742 (class 2604 OID 16420)
-- Name: Permission PermissionId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Permission" ALTER COLUMN "PermissionId" SET DEFAULT nextval('public."Permission_PermissionId_seq"'::regclass);


--
-- TOC entry 4745 (class 2604 OID 16443)
-- Name: Project ProjectId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Project" ALTER COLUMN "ProjectId" SET DEFAULT nextval('public."Project_ProjectId_seq"'::regclass);


--
-- TOC entry 4751 (class 2604 OID 16473)
-- Name: ProjectUser ProjectUserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUser" ALTER COLUMN "ProjectUserId" SET DEFAULT nextval('public."ProjectUser_ProjectUserId_seq"'::regclass);


--
-- TOC entry 4755 (class 2604 OID 16498)
-- Name: ProjectUserInvite InviteId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProjectUserInvite" ALTER COLUMN "InviteId" SET DEFAULT nextval('public."ProjectUserInvite_InviteId_seq"'::regclass);


--
-- TOC entry 4749 (class 2604 OID 16463)
-- Name: Request RequestId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);


--
-- TOC entry 4741 (class 2604 OID 16411)
-- Name: Role RoleId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);


--
-- TOC entry 4744 (class 2604 OID 16436)
-- Name: RoleMenuAccess AccessId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMenuAccess" ALTER COLUMN "AccessId" SET DEFAULT nextval('public."RoleMenuAccess_AccessId_seq"'::regclass);


--
-- TOC entry 4747 (class 2604 OID 16453)
-- Name: Task TaskId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Task" ALTER COLUMN "TaskId" SET DEFAULT nextval('public."Task_TaskId_seq"'::regclass);


--
-- TOC entry 4740 (class 2604 OID 16393)
-- Name: Users UserId; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "UserId" SET DEFAULT nextval('public."User_UserId_seq"'::regclass);


--
-- TOC entry 4949 (class 0 OID 16478)
-- Dependencies: 236
-- Data for Name: Comment; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4937 (class 0 OID 16424)
-- Dependencies: 224
-- Data for Name: Menu; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Menu" ("MenuId", "MenuName", "MenuUrl", "ParentMenuId", "IsVisible") VALUES (1, 'Project', '/project', NULL, true);
INSERT INTO public."Menu" ("MenuId", "MenuName", "MenuUrl", "ParentMenuId", "IsVisible") VALUES (2, 'Task', '/task', NULL, true);
INSERT INTO public."Menu" ("MenuId", "MenuName", "MenuUrl", "ParentMenuId", "IsVisible") VALUES (3, 'Users', '/users', NULL, true);


--
-- TOC entry 4935 (class 0 OID 16417)
-- Dependencies: 222
-- Data for Name: Permission; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (2, 'Task', true, false, false, false);
INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (1, 'Project', true, false, true, true);
INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (4, 'Project', true, false, false, false);
INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (6, 'Task', true, true, true, false);
INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (7, 'Project', true, true, true, true);
INSERT INTO public."Permission" ("PermissionId", "TableName", "CanView", "CanAdd", "CanEdit", "CanDelete") VALUES (3, 'Users', true, false, true, true);


--
-- TOC entry 4941 (class 0 OID 16440)
-- Dependencies: 228
-- Data for Name: Project; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4947 (class 0 OID 16470)
-- Dependencies: 234
-- Data for Name: ProjectUser; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4951 (class 0 OID 16495)
-- Dependencies: 238
-- Data for Name: ProjectUserInvite; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4945 (class 0 OID 16460)
-- Dependencies: 232
-- Data for Name: Request; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4933 (class 0 OID 16408)
-- Dependencies: 220
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (1, 'Project', 'Project');
INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (2, 'Task', 'Task');
INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (3, 'Menu', 'Menu');
INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (4, '', '');
INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (6, '', '');
INSERT INTO public."Role" ("RoleId", "RoleName", "Description") VALUES (7, '', '');


--
-- TOC entry 4939 (class 0 OID 16433)
-- Dependencies: 226
-- Data for Name: RoleMenuAccess; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (1, 1, true, 1);
INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (2, 2, true, 2);
INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (3, 3, true, 3);
INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (4, 1, true, 4);
INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (6, 2, true, 6);
INSERT INTO public."RoleMenuAccess" ("AccessId", "MenuId", "CanAccess", "RoleId") VALUES (7, 1, true, 7);


--
-- TOC entry 4952 (class 0 OID 16503)
-- Dependencies: 239
-- Data for Name: RolePermissions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (1, 1, 1);
INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (2, 2, 2);
INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (3, 3, 3);
INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (4, 4, 4);
INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (6, 6, 6);
INSERT INTO public."RolePermissions" ("Id", "RoleId", "PermissionId") VALUES (7, 7, 7);


--
-- TOC entry 4943 (class 0 OID 16450)
-- Dependencies: 230
-- Data for Name: Task; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4953 (class 0 OID 16508)
-- Dependencies: 240
-- Data for Name: UserRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (1, 1, 1);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (2, 1, 2);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (3, 1, 3);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (5, 2, 2);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (4, 2, 4);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (7, 3, 6);
INSERT INTO public."UserRole" ("Id", "UserId", "RoleId") VALUES (8, 3, 7);


--
-- TOC entry 4931 (class 0 OID 16390)
-- Dependencies: 218
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

