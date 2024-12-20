PGDMP                  
    |         	   KyotoDesk    17.2    17.2 2    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    16557 	   KyotoDesk    DATABASE     �   CREATE DATABASE "KyotoDesk" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
    DROP DATABASE "KyotoDesk";
                     postgres    false            �            1255    16654    sp_get_sale(integer)    FUNCTION     �  CREATE FUNCTION public.sp_get_sale(p_venda_id integer) RETURNS json
    LANGUAGE plpgsql
    AS $$
DECLARE
    venda_info JSON;
BEGIN
    -- Constrói o JSON da venda
    SELECT 
        json_build_object(
            'venda_id', v.id,
            'cliente', c.nome,
            'data_venda', v.data_venda,
            'total_venda', v.total,
            'produtos', (
                SELECT json_agg(
                    json_build_object(
                        'produto', p.nome,
                        'quantidade', vp.quantidade,
                        'preco_unitario', p.preco,
                        'preco_total', p.preco * vp.quantidade
                    )
                )
                FROM vendas_produtos vp
                JOIN produtos p ON vp.produto_id = p.id
                WHERE vp.venda_id = v.id
            )
        )
    INTO venda_info
    FROM vendas v
    JOIN clientes c ON v.cliente_id = c.id
    WHERE v.id = p_venda_id;

    -- Verifica se a venda foi encontrada
    IF venda_info IS NULL THEN
        RAISE EXCEPTION 'Venda não encontrada para o ID %', p_venda_id;
    END IF;

    RETURN venda_info;
END;
$$;
 6   DROP FUNCTION public.sp_get_sale(p_venda_id integer);
       public               postgres    false            �            1255    16612 \   sp_insert_client(character varying, character varying, character varying, character varying)    FUNCTION     E  CREATE FUNCTION public.sp_insert_client(p_nome character varying, p_endereco character varying, p_telefone character varying, p_email character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO clientes (nome, endereco, telefone, email)
    VALUES (p_nome, p_endereco, p_telefone, p_email);
END;
$$;
 �   DROP FUNCTION public.sp_insert_client(p_nome character varying, p_endereco character varying, p_telefone character varying, p_email character varying);
       public               postgres    false            �            1255    16623 I   sp_insert_product(character varying, character varying, numeric, integer) 	   PROCEDURE     Y  CREATE PROCEDURE public.sp_insert_product(IN p_nome character varying, IN p_descricao character varying, IN p_preco numeric, IN p_estoque integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Insere o novo produto na tabela
    INSERT INTO produtos (nome, descricao, preco, estoque)
    VALUES (p_nome, p_descricao, p_preco, p_estoque);
END;
$$;
 �   DROP PROCEDURE public.sp_insert_product(IN p_nome character varying, IN p_descricao character varying, IN p_preco numeric, IN p_estoque integer);
       public               postgres    false            �            1255    16616    sp_list_client()    FUNCTION     �  CREATE FUNCTION public.sp_list_client() RETURNS TABLE(cliente_id integer, nome_cliente character varying, endereco_cliente character varying, telefone_cliente character varying, email_cliente character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        id AS cliente_id,
        nome AS nome_cliente,
        endereco AS endereco_cliente,
        telefone AS telefone_cliente,
        email AS email_cliente
    FROM clientes
    ORDER BY id;
END;
$$;
 '   DROP FUNCTION public.sp_list_client();
       public               postgres    false            �            1255    16656    sp_list_client_purchases()    FUNCTION     �  CREATE FUNCTION public.sp_list_client_purchases() RETURNS TABLE(cliente_id integer, cliente character varying, endereco character varying, telefone character varying, email character varying, total_vendas bigint, valor_total_compras numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        c.id AS cliente_id,
        c.nome AS cliente,
        c.endereco,
        c.telefone,
        c.email,
        COUNT(v.id) AS total_vendas, -- COUNT retorna BIGINT
        COALESCE(SUM(v.total), 0) AS valor_total_compras
    FROM 
        clientes c
    LEFT JOIN 
        vendas v ON c.id = v.cliente_id
    GROUP BY 
        c.id
    ORDER BY 
        total_vendas DESC, valor_total_compras DESC;
END;
$$;
 1   DROP FUNCTION public.sp_list_client_purchases();
       public               postgres    false            �            1259    16566    produtos    TABLE     M  CREATE TABLE public.produtos (
    id integer NOT NULL,
    nome character varying(100) NOT NULL,
    descricao character varying(255),
    preco numeric(10,2) NOT NULL,
    estoque integer NOT NULL,
    CONSTRAINT produtos_estoque_check CHECK ((estoque >= 0)),
    CONSTRAINT produtos_preco_check CHECK ((preco >= (0)::numeric))
);
    DROP TABLE public.produtos;
       public         heap r       postgres    false            �            1255    16620    sp_list_product()    FUNCTION     -  CREATE FUNCTION public.sp_list_product() RETURNS SETOF public.produtos
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Retorna todos os produtos da tabela
    RETURN QUERY
    SELECT id as ID, nome as Nome, descricao as Descricao, preco as Preco,
	estoque as  Estoque FROM produtos
	ORDER BY id;
END;
$$;
 (   DROP FUNCTION public.sp_list_product();
       public               postgres    false    220            �            1255    16648    sp_list_sales()    FUNCTION     �  CREATE FUNCTION public.sp_list_sales() RETURNS TABLE(venda_id integer, cliente character varying, data_venda timestamp without time zone, total_venda numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        v.id AS venda_id,
        c.nome AS cliente,
        v.data_venda,
        v.total AS total_venda
    FROM 
        vendas v
    JOIN 
        clientes c ON v.cliente_id = c.id
    ORDER BY 
        v.data_venda DESC;
END;
$$;
 &   DROP FUNCTION public.sp_list_sales();
       public               postgres    false            �            1255    16624    sp_register_sale(integer, json)    FUNCTION     ,  CREATE FUNCTION public.sp_register_sale(p_cliente_id integer, p_itens json) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
    item RECORD;
    venda_id INT;
    total_venda NUMERIC(10, 2) := 0;
    preco_produto NUMERIC(10, 2);
    estoque_atual INT;
BEGIN
    -- Insere a venda inicialmente sem o total
    INSERT INTO vendas (cliente_id, data_venda, total)
    VALUES (p_cliente_id, NOW(), 0)
    RETURNING id INTO venda_id;

    -- Processa os itens da venda
    FOR item IN SELECT * FROM json_to_recordset(p_itens) AS (produto_id INT, quantidade INT) LOOP
        -- Verifica o estoque disponível do produto
        SELECT estoque INTO estoque_atual
        FROM produtos
        WHERE id = item.produto_id;

        IF estoque_atual < item.quantidade THEN
            RAISE EXCEPTION 'Estoque insuficiente para o produto %', item.produto_id;
        END IF;

        -- Obtém o preço do produto
        SELECT preco INTO preco_produto
        FROM produtos
        WHERE id = item.produto_id;

        -- Insere na tabela vendas_produtos
        INSERT INTO vendas_produtos (venda_id, produto_id, quantidade)
        VALUES (venda_id, item.produto_id, item.quantidade);

        -- Atualiza o estoque do produto
        UPDATE produtos
        SET estoque = estoque - item.quantidade
        WHERE id = item.produto_id;

        -- Atualiza o total da venda
        total_venda := total_venda + (preco_produto * item.quantidade);
    END LOOP;

    -- Atualiza o total na tabela vendas
    UPDATE vendas
    SET total = total_venda
    WHERE id = venda_id;
END;
$$;
 K   DROP FUNCTION public.sp_register_sale(p_cliente_id integer, p_itens json);
       public               postgres    false            �            1255    16618    sp_remove_client(integer) 	   PROCEDURE       CREATE PROCEDURE public.sp_remove_client(IN p_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM clientes
    WHERE id = p_id;

    -- Verifica se o cliente foi removido
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Cliente não encontrado';
    END IF;
END;
$$;
 9   DROP PROCEDURE public.sp_remove_client(IN p_id integer);
       public               postgres    false            �            1255    16622    sp_remove_product(integer) 	   PROCEDURE     �   CREATE PROCEDURE public.sp_remove_product(IN p_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM produtos
    WHERE id = p_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produto com ID % não encontrado', p_id;
    END IF;
END;
$$;
 :   DROP PROCEDURE public.sp_remove_product(IN p_id integer);
       public               postgres    false            �            1255    16617 e   sp_update_client(integer, character varying, character varying, character varying, character varying) 	   PROCEDURE     V  CREATE PROCEDURE public.sp_update_client(IN p_id integer, IN p_nome character varying, IN p_endereco character varying, IN p_telefone character varying, IN p_email character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE clientes
    SET nome = p_nome,
        endereco = p_endereco,
        telefone = p_telefone,
        email = p_email
    WHERE id = p_id;

     -- Verifica se a atualização foi bem-sucedida
    IF FOUND THEN
        RAISE NOTICE 'Cliente atualizado com sucesso';
    ELSE
        RAISE NOTICE 'Cliente não encontrado ou não foi atualizado';
    END IF;
END;
$$;
 �   DROP PROCEDURE public.sp_update_client(IN p_id integer, IN p_nome character varying, IN p_endereco character varying, IN p_telefone character varying, IN p_email character varying);
       public               postgres    false            �            1255    16621 R   sp_update_product(integer, character varying, character varying, numeric, integer) 	   PROCEDURE     �  CREATE PROCEDURE public.sp_update_product(IN p_id integer, IN p_nome character varying, IN p_descricao character varying, IN p_preco numeric, IN p_estoque integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE produtos
    SET nome = p_nome,
        descricao = p_descricao,
        preco = p_preco,
        estoque = p_estoque
    WHERE id = p_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produto com ID % não encontrado', p_id;
    END IF;
END;
$$;
 �   DROP PROCEDURE public.sp_update_product(IN p_id integer, IN p_nome character varying, IN p_descricao character varying, IN p_preco numeric, IN p_estoque integer);
       public               postgres    false            �            1259    16559    clientes    TABLE     �   CREATE TABLE public.clientes (
    id integer NOT NULL,
    nome character varying(100) NOT NULL,
    endereco character varying(255),
    telefone character varying(20),
    email character varying(100)
);
    DROP TABLE public.clientes;
       public         heap r       postgres    false            �            1259    16558    clientes_id_seq    SEQUENCE     �   CREATE SEQUENCE public.clientes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.clientes_id_seq;
       public               postgres    false    218            �           0    0    clientes_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.clientes_id_seq OWNED BY public.clientes.id;
          public               postgres    false    217            �            1259    16590    itens_venda    TABLE     i  CREATE TABLE public.itens_venda (
    id integer NOT NULL,
    venda_id integer NOT NULL,
    produto_id integer NOT NULL,
    quantidade integer NOT NULL,
    preco_unitario numeric(10,2) NOT NULL,
    CONSTRAINT itens_venda_preco_unitario_check CHECK ((preco_unitario >= (0)::numeric)),
    CONSTRAINT itens_venda_quantidade_check CHECK ((quantidade > 0))
);
    DROP TABLE public.itens_venda;
       public         heap r       postgres    false            �            1259    16589    itens_venda_id_seq    SEQUENCE     �   CREATE SEQUENCE public.itens_venda_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.itens_venda_id_seq;
       public               postgres    false    224            �           0    0    itens_venda_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.itens_venda_id_seq OWNED BY public.itens_venda.id;
          public               postgres    false    223            �            1259    16565    produtos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.produtos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.produtos_id_seq;
       public               postgres    false    220            �           0    0    produtos_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.produtos_id_seq OWNED BY public.produtos.id;
          public               postgres    false    219            �            1259    16649 
   venda_info    TABLE     ?   CREATE TABLE public.venda_info (
    json_build_object json
);
    DROP TABLE public.venda_info;
       public         heap r       postgres    false            �            1259    16577    vendas    TABLE     �   CREATE TABLE public.vendas (
    id integer NOT NULL,
    cliente_id integer NOT NULL,
    data_venda timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    total numeric(10,2) NOT NULL
);
    DROP TABLE public.vendas;
       public         heap r       postgres    false            �            1259    16576    vendas_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vendas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.vendas_id_seq;
       public               postgres    false    222            �           0    0    vendas_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.vendas_id_seq OWNED BY public.vendas.id;
          public               postgres    false    221            �            1259    16627    vendas_produtos    TABLE     �   CREATE TABLE public.vendas_produtos (
    id integer NOT NULL,
    venda_id integer NOT NULL,
    produto_id integer NOT NULL,
    quantidade integer NOT NULL,
    CONSTRAINT vendas_produtos_quantidade_check CHECK ((quantidade > 0))
);
 #   DROP TABLE public.vendas_produtos;
       public         heap r       postgres    false            �            1259    16626    vendas_produtos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vendas_produtos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.vendas_produtos_id_seq;
       public               postgres    false    226            �           0    0    vendas_produtos_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.vendas_produtos_id_seq OWNED BY public.vendas_produtos.id;
          public               postgres    false    225            E           2604    16562    clientes id    DEFAULT     j   ALTER TABLE ONLY public.clientes ALTER COLUMN id SET DEFAULT nextval('public.clientes_id_seq'::regclass);
 :   ALTER TABLE public.clientes ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    218    217    218            I           2604    16593    itens_venda id    DEFAULT     p   ALTER TABLE ONLY public.itens_venda ALTER COLUMN id SET DEFAULT nextval('public.itens_venda_id_seq'::regclass);
 =   ALTER TABLE public.itens_venda ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    224    223    224            F           2604    16569    produtos id    DEFAULT     j   ALTER TABLE ONLY public.produtos ALTER COLUMN id SET DEFAULT nextval('public.produtos_id_seq'::regclass);
 :   ALTER TABLE public.produtos ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    220    219    220            G           2604    16580 	   vendas id    DEFAULT     f   ALTER TABLE ONLY public.vendas ALTER COLUMN id SET DEFAULT nextval('public.vendas_id_seq'::regclass);
 8   ALTER TABLE public.vendas ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    221    222    222            J           2604    16630    vendas_produtos id    DEFAULT     x   ALTER TABLE ONLY public.vendas_produtos ALTER COLUMN id SET DEFAULT nextval('public.vendas_produtos_id_seq'::regclass);
 A   ALTER TABLE public.vendas_produtos ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    226    225    226            Q           2606    16564    clientes clientes_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.clientes
    ADD CONSTRAINT clientes_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.clientes DROP CONSTRAINT clientes_pkey;
       public                 postgres    false    218            Z           2606    16597    itens_venda itens_venda_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.itens_venda
    ADD CONSTRAINT itens_venda_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.itens_venda DROP CONSTRAINT itens_venda_pkey;
       public                 postgres    false    224            U           2606    16575    produtos produtos_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.produtos
    ADD CONSTRAINT produtos_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.produtos DROP CONSTRAINT produtos_pkey;
       public                 postgres    false    220            X           2606    16583    vendas vendas_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.vendas
    ADD CONSTRAINT vendas_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.vendas DROP CONSTRAINT vendas_pkey;
       public                 postgres    false    222            \           2606    16633 $   vendas_produtos vendas_produtos_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.vendas_produtos
    ADD CONSTRAINT vendas_produtos_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.vendas_produtos DROP CONSTRAINT vendas_produtos_pkey;
       public                 postgres    false    226            R           1259    16608    idx_cliente_email    INDEX     G   CREATE INDEX idx_cliente_email ON public.clientes USING btree (email);
 %   DROP INDEX public.idx_cliente_email;
       public                 postgres    false    218            S           1259    16609    idx_produto_nome    INDEX     E   CREATE INDEX idx_produto_nome ON public.produtos USING btree (nome);
 $   DROP INDEX public.idx_produto_nome;
       public                 postgres    false    220            V           1259    16610    idx_venda_data    INDEX     G   CREATE INDEX idx_venda_data ON public.vendas USING btree (data_venda);
 "   DROP INDEX public.idx_venda_data;
       public                 postgres    false    222            ^           2606    16603 '   itens_venda itens_venda_produto_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.itens_venda
    ADD CONSTRAINT itens_venda_produto_id_fkey FOREIGN KEY (produto_id) REFERENCES public.produtos(id) ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.itens_venda DROP CONSTRAINT itens_venda_produto_id_fkey;
       public               postgres    false    220    4693    224            _           2606    16598 %   itens_venda itens_venda_venda_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.itens_venda
    ADD CONSTRAINT itens_venda_venda_id_fkey FOREIGN KEY (venda_id) REFERENCES public.vendas(id) ON DELETE CASCADE;
 O   ALTER TABLE ONLY public.itens_venda DROP CONSTRAINT itens_venda_venda_id_fkey;
       public               postgres    false    222    4696    224            ]           2606    16584    vendas vendas_cliente_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.vendas
    ADD CONSTRAINT vendas_cliente_id_fkey FOREIGN KEY (cliente_id) REFERENCES public.clientes(id) ON DELETE CASCADE;
 G   ALTER TABLE ONLY public.vendas DROP CONSTRAINT vendas_cliente_id_fkey;
       public               postgres    false    218    222    4689            `           2606    16639 /   vendas_produtos vendas_produtos_produto_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.vendas_produtos
    ADD CONSTRAINT vendas_produtos_produto_id_fkey FOREIGN KEY (produto_id) REFERENCES public.produtos(id);
 Y   ALTER TABLE ONLY public.vendas_produtos DROP CONSTRAINT vendas_produtos_produto_id_fkey;
       public               postgres    false    220    4693    226            a           2606    16634 -   vendas_produtos vendas_produtos_venda_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.vendas_produtos
    ADD CONSTRAINT vendas_produtos_venda_id_fkey FOREIGN KEY (venda_id) REFERENCES public.vendas(id) ON DELETE CASCADE;
 W   ALTER TABLE ONLY public.vendas_produtos DROP CONSTRAINT vendas_produtos_venda_id_fkey;
       public               postgres    false    4696    222    226           