using System;

class NodoAVL
{
    public int Valor;
    public NodoAVL? Izquierdo, Derecho;  
    public int Altura;

    public NodoAVL(int valor)
    {
        Valor = valor;
        Altura = 1;
    }
}

class ArbolAVL
{
    private NodoAVL? raiz;                

    private int Altura(NodoAVL? nodo) => nodo?.Altura ?? 0;

    private int FactorBalance(NodoAVL? nodo) =>
        nodo == null ? 0 : Altura(nodo.Izquierdo) - Altura(nodo.Derecho);

    private void ActualizarAltura(NodoAVL nodo)
    {
        nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierdo), Altura(nodo.Derecho));
    }

    private NodoAVL RotarDerecha(NodoAVL y)
{
    NodoAVL x   = y.Izquierdo!;
    NodoAVL? T2 = x.Derecho;      

    x.Derecho   = y;
    y.Izquierdo = T2;

    ActualizarAltura(y);
    ActualizarAltura(x);
    Console.WriteLine($"  >> Rotación derecha en nodo {y.Valor}");
    return x;
}

private NodoAVL RotarIzquierda(NodoAVL x)
{
    NodoAVL y   = x.Derecho!;
    NodoAVL? T2 = y.Izquierdo;    

    y.Izquierdo = x;
    x.Derecho   = T2;

    ActualizarAltura(x);
    ActualizarAltura(y);
    Console.WriteLine($"  >> Rotación izquierda en nodo {x.Valor}");
    return y;
}
    public void Insertar(int valor)
    {
        Console.WriteLine($"\nInsertando: {valor}");
        raiz = Insertar(raiz, valor);
    }

    private NodoAVL Insertar(NodoAVL? nodo, int valor)  
    {
        if (nodo == null) return new NodoAVL(valor);

        if      (valor < nodo.Valor) nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor) nodo.Derecho   = Insertar(nodo.Derecho,   valor);
        else return nodo;

        ActualizarAltura(nodo);
        int balance = FactorBalance(nodo);

        if (balance > 1 && valor < nodo.Izquierdo!.Valor)  
            return RotarDerecha(nodo);

        if (balance < -1 && valor > nodo.Derecho!.Valor)   
            return RotarIzquierda(nodo);

        if (balance > 1 && valor > nodo.Izquierdo!.Valor)
        {
            Console.WriteLine($"  >> Rotación doble LR en nodo {nodo.Valor}");
            nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
            return RotarDerecha(nodo);
        }

        if (balance < -1 && valor < nodo.Derecho!.Valor)
        {
            Console.WriteLine($"  >> Rotación doble RL en nodo {nodo.Valor}");
            nodo.Derecho = RotarDerecha(nodo.Derecho);
            return RotarIzquierda(nodo);
        }

        return nodo;
    }

    public void MostrarInOrder()
    {
        Console.Write("In-Order (ascendente): ");
        InOrder(raiz);
        Console.WriteLine();
    }

    private void InOrder(NodoAVL? nodo)          
    {
        if (nodo == null) return;
        InOrder(nodo.Izquierdo);
        Console.Write($"{nodo.Valor}({nodo.Altura}) ");
        InOrder(nodo.Derecho);
    }

    public bool Buscar(int valor)
    {
        NodoAVL? actual = raiz;                  
        while (actual != null)
        {
            if      (valor == actual.Valor) return true;
            else if (valor <  actual.Valor) actual = actual.Izquierdo;
            else                            actual  = actual.Derecho;
        }
        return false;
    }

    public void MostrarEstructura()
    {
        Console.WriteLine("\nEstructura del árbol (raíz arriba):");
        MostrarNivel(raiz, "", true);
    }

    private void MostrarNivel(NodoAVL? nodo, string prefijo, bool esRaiz)  
    {
        if (nodo == null) return;
        Console.WriteLine(prefijo + "── " +
            $"{nodo.Valor} [h={nodo.Altura}, fb={FactorBalance(nodo)}]");

        string nuevoPrefijo = prefijo + "   ";
        if (nodo.Izquierdo != null)
            MostrarNivel(nodo.Izquierdo, nuevoPrefijo + "├─(I)", false);
        if (nodo.Derecho != null)
            MostrarNivel(nodo.Derecho,   nuevoPrefijo + "└─(D)", false);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Demo Árbol AVL ===");
        ArbolAVL avl = new ArbolAVL();

        int[] valores = { 10, 20, 30, 40, 50, 25 };
        foreach (int v in valores)
            avl.Insertar(v);

        Console.WriteLine("\n--- Estado final ---");
        avl.MostrarEstructura();
        avl.MostrarInOrder();

        Console.WriteLine("\n--- Búsquedas ---");
        Console.WriteLine($"¿Existe 25? {avl.Buscar(25)}");
        Console.WriteLine($"¿Existe 99? {avl.Buscar(99)}");
    }
}
