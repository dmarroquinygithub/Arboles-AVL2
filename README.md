# Arboles-AVL
Darvin Aroldo Marroquín y Marroquín 0907-24-6922   Programacion III



Que es un Arbol AVL?

Un árbol AVL es un tipo de árbol binario de búsqueda que se mantiene siempre equilibrado para que las operaciones sean rápidas. 
Su nombre viene de sus creadores, Adelson-Velsky y Landis, y su idea principal es evitar que el árbol se “incline” demasiado hacia un lado.

En un árbol binario de búsqueda normal, los valores menores se colocan a la izquierda y los mayores a la derecha. 
Eso permite ordenar los datos, pero si insertas elementos en un orden desfavorable, el árbol puede deformarse y volverse muy profundo. 
En cambio, el árbol AVL controla ese problema manteniendo la diferencia de altura entre el subárbol izquierdo y derecho de cada nodo en no más de 1.

Ese control de altura se llama factor de equilibrio. Si un nodo se desbalancea después de insertar o eliminar un valor, 
el árbol aplica una rotación para recuperar el equilibrio. Estas rotaciones pueden ser simples o dobles, según el caso.

Rotaciones más comunes

Las rotaciones sirven para reorganizar nodos sin perder el orden del árbol. Las principales son:
  
  Rotación a la derecha.
  
  Rotación a la izquierda.
  
  Rotación doble izquierda-derecha.
  
  Rotación doble derecha-izquierda.

La gran ventaja de los AVL es que mantienen las operaciones de búsqueda, inserción y eliminación en tiempo eficiente, normalmente. 
Eso significa que incluso con muchos datos, el rendimiento sigue siendo bueno porque el árbol no crece de forma descontrolada. 
Por eso se usan en sistemas donde importa mucho la velocidad de acceso a datos ordenados.

Ejemplo sencillo
Imagina que insertas los números 10, 20 y 30 en un árbol binario normal. Sin equilibrio, 
todos quedarían acomodados hacia la derecha y el árbol parecería una lista. Un AVL detecta e
se desbalance y hace una rotación para que el 20 quede como raíz, con 10 a la izquierda y 30 a la derecha
