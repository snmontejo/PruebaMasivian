# PruebaMasivian
CLEAN CODE Ruleta

<pre><code>
1. Endpoint de creación de nuevas ruletas que devuelva el id de la nueva ruleta creada
2. Endpoint de apertura de ruleta (el input es un id de ruleta) que permita las
  posteriores peticiones de apuestas, este debe devolver simplemente un estado que
  confirme que la operación fue exitosa o denegada
3 Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36)
  o color (negro o rojo) de la ruleta una cantidad determinada de dinero (máximo
  10.000 dólares) a una ruleta abierta.
  (nota: este enpoint recibe además de los parámetros de la apuesta, un id de usuario
  en los HEADERS asumiendo que el servicio que haga la petición ya realizo una
  autenticación y validación de que el cliente tiene el crédito necesario para realizar la
  apuesta)
4 Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el
 resultado de las apuestas hechas desde su apertura hasta el cierre.
5 Endpoint de listado de ruletas creadas con sus estados (abierta o cerrada)
</code></pre>


<p><strong>1. Endpoint de creaci&oacute;n de nuevas ruletas que devuelva el id de la nueva ruleta creada</strong></p>


curl --location --request POST 'http://localhost:64971/Roulette/create' 


<p>RESULTADO:</p>

  <pre><code>
3
  </code></pre>

<p><strong>2.  Endpoint de apertura de ruleta (el input es un id de ruleta) que permita las
  posteriores peticiones de apuestas, este debe devolver simplemente un estado que
  confirme que la operación fue exitosa o denegada</strong></p>
  
  curl --location --request POST 'http://localhost:64971/Roulette/open?id=3' 
--header 'id: 1' 
--data-raw ''
  
  <p>RESULTADO:</p>
    <pre><code>
  "Operacion Exitosa"
  </code></pre>
  
<p><strong>3. Endpoint de apuesta a un número (los números válidos para apostar son del 0 al 36)
  o color (negro o rojo) de la ruleta una cantidad determinada de dinero (máximo
  10.000 dólares) a una ruleta abierta.
  (nota: este enpoint recibe además de los parámetros de la apuesta, un id de usuario
  en los HEADERS asumiendo que el servicio que haga la petición ya realizo una
  autenticación y validación de que el cliente tiene el crédito necesario para realizar la
  apuesta)</strong></p>

curl --location --request POST 'http://localhost:64971/Roulette/bet?user=darwing&idroulette=3&number=10&money=8000' 
http://localhost:64971/Roulette/bet?user=smontejo&idroulette=3&number=10&money=8000
--data-raw ''

 <p>RESULTADO:</p>
 
  <pre><code>
 "Apuesta Exitosa"
 </code></pre>
 
 <p><strong>4. Endpoint de cierre apuestas dado un id de ruleta, este endpoint debe devolver el
 resultado de las apuestas hechas desde su apertura hasta el cierre.</strong></p>
 
 curl --location --request POST 'http://localhost:64971/Roulette/close?idroulette=3' 
--data-raw ''

 <p>RESULTADO:</p>
 <pre><code>[
    {
        "id": 6,
        "id_roulette": 3,
        "user_": "darwing",
        "number": 10,
        "money": 8000.0
    },
    {
        "id": 7,
        "id_roulette": 3,
        "user_": "smontejo",
        "number": 10,
        "money": 8000.0
    }
]
</code></pre>
 
  <p><strong>5 Endpoint de listado de ruletas creadas con sus estados (abierta o cerrada)</strong></p>
  
  curl --location --request POST 'http://localhost:64971/Roulette/list'
--data-raw ''

 <p>RESULTADO:</p>
 <pre><code>
 [
    {
        "id": 1,
        "isOpen": true,
        "dateOpen": "2021-01-24T00:00:00",
        "dateClose": null
    },
    {
        "id": 2,
        "isOpen": false,
        "dateOpen": "2021-01-24T00:00:00",
        "dateClose": "2021-01-24T00:00:00"
    },
    {
        "id": 3,
        "isOpen": false,
        "dateOpen": "2021-01-25T00:00:00",
        "dateClose": "2021-01-25T00:00:00"
    }
]
 
 
 </code></pre>
 


  
  
