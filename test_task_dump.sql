PGDMP  )    7            
    {         	   test_task    16.0    16.0     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    24576 	   test_task    DATABASE     }   CREATE DATABASE test_task WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE test_task;
                postgres    false            �            1259    24583    brands    TABLE     �   CREATE TABLE public.brands (
    brand_id integer NOT NULL,
    brand_name character varying(50) NOT NULL,
    brand_active boolean DEFAULT false NOT NULL
);
    DROP TABLE public.brands;
       public         heap    postgres    false            �            1259    24646    brands_brand_id_seq    SEQUENCE     �   ALTER TABLE public.brands ALTER COLUMN brand_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.brands_brand_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1231233
    CACHE 1
);
            public          postgres    false    215            �            1259    24586    models    TABLE     �   CREATE TABLE public.models (
    model_id integer NOT NULL,
    model_name character varying(50) NOT NULL,
    model_brand_id integer NOT NULL,
    model_active boolean DEFAULT false NOT NULL
);
    DROP TABLE public.models;
       public         heap    postgres    false            �            1259    24647    models_model_id_seq    SEQUENCE     �   ALTER TABLE public.models ALTER COLUMN model_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.models_model_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 123123
    CACHE 1
);
            public          postgres    false    216            �          0    24583    brands 
   TABLE DATA           D   COPY public.brands (brand_id, brand_name, brand_active) FROM stdin;
    public          postgres    false    215   �       �          0    24586    models 
   TABLE DATA           T   COPY public.models (model_id, model_name, model_brand_id, model_active) FROM stdin;
    public          postgres    false    216   i       �           0    0    brands_brand_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.brands_brand_id_seq', 17, true);
          public          postgres    false    217            �           0    0    models_model_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.models_model_id_seq', 34, true);
          public          postgres    false    218            "           2606    24613    brands brands_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.brands
    ADD CONSTRAINT brands_pkey PRIMARY KEY (brand_id);
 <   ALTER TABLE ONLY public.brands DROP CONSTRAINT brands_pkey;
       public            postgres    false    215            $           2606    24640    models models_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.models
    ADD CONSTRAINT models_pkey PRIMARY KEY (model_id);
 <   ALTER TABLE ONLY public.models DROP CONSTRAINT models_pkey;
       public            postgres    false    216            %           2606    24641    models fk_mode_brand    FK CONSTRAINT     �   ALTER TABLE ONLY public.models
    ADD CONSTRAINT fk_mode_brand FOREIGN KEY (model_brand_id) REFERENCES public.brands(brand_id) NOT VALID;
 >   ALTER TABLE ONLY public.models DROP CONSTRAINT fk_mode_brand;
       public          postgres    false    4642    215    216            �   u   x�3����..OLO��,�2�t�/J2,8=*K�R3�lKN�ҔL�4.C΀����T��/��8�ˈ��7(d��_�_�2��M-JNMI-�uJͫ�
�rz�M�b���� v "L      �     x�M�IJ�@��N�����"t���H���d &�A��ǥ�辑�R���|�{5����C;���%�&�ƶ���<*G����6��m�ҙ��FW���ig�	�j��m�0D�����meEB�0����?:��]��2�7����7%���L4F��,��g*X9���F
h5Ė�ΣALF�/�4��H��1�]����H�ĸW+0��U"���I�O��WSg	�B՞,+��r���l�3�~���/:F�����-S�ӏ[��t�)'CX{�W�����iO     