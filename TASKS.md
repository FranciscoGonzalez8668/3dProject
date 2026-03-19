# TASKS – Diplomatura Videojuegos (Tareas)
> Claude Code lee este archivo automáticamente. Actualizalo al final de cada sesión.

---

## 🔄 En progreso

- [ ] TP3 – Minigolf (pendiente entrega)

---

## ⏳ Pendiente

### TP3 – Minigolf

#### Parte 1 — Spawn al soltar Space
- [ ] Crear script `SpawnOnRelease.cs`
- [ ] Detectar cuando se suelta la tecla Space con `Input.GetKeyUp(KeyCode.Space)`
- [ ] Crear un GameObject vacío llamado "SpawnPoint" y posicionarlo en la escena
- [ ] Asignar referencia del SpawnPoint en el script (variable pública o `[SerializeField]`)
- [ ] Al soltar Space, mover la esfera a la posición del SpawnPoint con `transform.position`
- [ ] Asignar el script al GameObject de la esfera y probar

#### Parte 2 — Medir tiempo de clic del mouse
- [ ] Crear script `ClickTimer.cs`
- [ ] Detectar presión del mouse con `Input.GetMouseButtonDown(0)` y guardar `Time.time`
- [ ] Detectar soltada del mouse con `Input.GetMouseButtonUp(0)` y calcular la diferencia
- [ ] Mostrar el tiempo transcurrido por consola con `Debug.Log`
- [ ] Asignar el script a un GameObject vacío o a la esfera y probar

#### Parte 3 — Aplicar fuerza de impulso según tiempo de clic
- [ ] Extender `ClickTimer.cs` (o crear `GolfShot.cs` que lo reemplace)
- [ ] Asegurarse que la esfera tiene componente Rigidbody
- [ ] Al soltar el mouse, calcular fuerza = tiempo de clic * un multiplicador (variable pública)
- [ ] Aplicar la fuerza hacia adelante con `rb.AddForce(transform.forward * fuerza, ForceMode.Impulse)`
- [ ] Ajustar el multiplicador en el Inspector hasta que se sienta bien
- [ ] Probar que a más tiempo presionado, mayor sea el impulso

#### Parte 4 — Trigger para cambiar de escena
- [ ] Crear script `SceneChanger.cs`
- [ ] Agregar `using UnityEngine.SceneManagement;` al script
- [ ] Implementar `OnTriggerEnter(Collider other)` que llame a `SceneManager.LoadScene()`
- [ ] Crear un GameObject "Hoyo" con Collider marcado como "Is Trigger"
- [ ] Opcionalmente: verificar que el objeto que entró es la esfera (por tag o nombre)
- [ ] Crear al menos una segunda escena en el proyecto (File > New Scene)
- [ ] Agregar ambas escenas en Build Settings (File > Build Settings > Add Open Scenes)
- [ ] Asignar el script al GameObject "Hoyo" y probar la transición

#### Parte 5 — Prototipo de Minigolf completo
- [ ] Diseñar al menos 2 niveles/configuraciones distintas en escenas separadas
- [ ] Cada nivel debe tener: esfera jugable, SpawnPoint, hoyo con trigger, obstáculos o paredes
- [ ] Armar geometría de los "hoyos" con cubos y planos (sin assets externos necesarios)
- [ ] Asignar materiales o colores distintos a cada nivel para diferenciarlos
- [ ] Verificar que los scripts de las partes 1–4 funcionan integrados en cada nivel
- [ ] Probar el flujo completo: spawn → golpe → trigger → siguiente escena
- [ ] Ajustar física de la esfera (masa, drag, angular drag) para que ruede bien

#### Entrega
- [ ] Comprimir proyecto en ZIP
- [ ] Subir ZIP al Drive y dejar link público
- [ ] Entregar en doctaonline.com

---

## ✅ Terminado

- [x] TP1 – Generación de Ideas (spreadsheet entregado)
- [x] Escena con pelotas cayendo y Rigidbody creada

### TP2 – Basic Projectile: Juego de disparos al blanco

#### Parte 1 — Ciclo de vida de Unity
- [x] Crear script `LifeCycleTest.cs`
- [x] Agregar Debug.Log en Awake, Start y Update
- [x] Dar Play y verificar el orden en consola

#### Parte 2 — Variable que disminuye en el tiempo
- [x] Crear script `CountdownValue.cs` (creado como `CountDown.cs`)
- [x] Declarar variable float con valor inicial
- [x] Reducirla en Update usando Time.deltaTime
- [x] Puede representar: vida, tiempo, combustible, etc.

#### Parte 3 — Mover GameObject con Translate
- [x] Crear script `Mover.cs` (creado como `Move.cs`)
- [x] Usar `transform.Translate()` para mover hacia adelante
- [x] Probar velocidad con variable pública

#### Parte 4 — Proyectil con detección de colisión
- [x] Crear GameObject "Proyectil"
- [x] Agregar Rigidbody y Collider
- [x] Crear script `Projectile.cs`
- [x] Al colisionar con otro GameObject: desactivarlo
- [x] Probar que funcione en escena

#### Parte 5 — Algo divertido
- [x] Definir la mecánica divertida (proyectil que rompe cubos en pedazos)
- [x] Implementar disparo desde un punto de origen
- [x] Agregar físicas interesantes (AddExplosionForce + Destroy con delay)
- [x] Testear que se sienta bien

#### Entrega
- [x] Comprimir proyecto en ZIP
- [x] Subir ZIP al Drive y dejar link público
- [x] Entregar en doctaonline.com

---

## 📝 Notas de sesiones

| Fecha | Tarea | Resultado | Notas |
|-------|-------|-----------|-------|
| -     | Setup inicial | CLAUDE.md + TASKS.md listos | Arrancar por Parte 1 |
