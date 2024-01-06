<h1 align="center"> TPLabo2-Ajedrez: <i> El problema de la cobertura del tablero de ajedrez </i> </h1>

<h3> <i> Josef Kling 1849 </i> </h3>
<u1>El problema de la cobertura del tablero de ajedrez</u1>
Amenazar en simultaneo las 64 casillas del tablero usando las 8 piezas principales del ajedrez.
<h>Ejemplo de solucion: </h>
<img src="https://github.com/MailenZino/TPLabo2-Ajedrez/assets/84191140/fdf7fae8-d282-43a7-8e12-211f50cced89" alt="solucion">

<h2> Objetivo TP: </h2> 
Construir un algoritmo que muestre al menos 100 tableros donde TODA casilla está siendo atacada.
<u> ! Las piezas no amenazan el casillero en el que se encuentran paradas </u> 
<u> ! Pueden superponerse en la misma casilla </u> 
<h2><a href="[https://www.w3schools.com/](https://docs.google.com/document/d/1G1dqeS-hC3CvVHTod7haPKCv1eacSh86rtbDLmdSSts/edit?usp=sharing)"> Solucion: </a> </h2> 
- Torres: se posicionaron en 0,0 y 1,1  reduciendo el tablero a 6x6 para colocar el resto de las piezas.
- Alfiles: se colocaron de manera aleatoria para que cubran las diagonales del 6x6
- Reina: se coloco donde habia un casillero atacado sabiendo que no podia ser la misma del alfiler
- Rey: se analizan cuadrados 3x3 para ubicar al rey donde más espacios vacíos haya
- Caballos: se coloca en las posiciones libres y se verifica que no queden casillas libres
_Una vez encontrada una solucion se conserva la posicion relativa entre fichas rotando el tablero, espejandolo y moviendo las torres_
