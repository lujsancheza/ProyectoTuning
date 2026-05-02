# Feature Specification: Avatar Emotional Experiment Foundation

**Feature Branch**: `[001-avatar-emotional-foundation]`  
**Created**: 2026-04-30  
**Status**: Draft  
**Input**: User description: "Base inicial derivada del C4 del Sistema Experimental de Avatar Emocional para organizar módulos, límites y slices dentro de Clean Architecture y Spec Kit."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Ejecutar un ensayo conversacional completo (Priority: P1)

Como participante del experimento, necesito completar un ensayo conversacional con un avatar emocional, de forma que pueda interactuar con el interlocutor y terminar el flujo con el cuestionario asociado.

**Why this priority**: Es el flujo principal del producto. Sin un ensayo completo no existe experimento, ni datos, ni validación del resto de módulos.

**Independent Test**: Puede probarse iniciando una sesión, asignando una condición de ensayo, intercambiando mensajes por el cliente web y cerrando el flujo con cuestionarios persistidos.

**Acceptance Scenarios**:

1. **Given** un participante inicia un ensayo, **When** el sistema crea la sesión y asigna la condición Humano o IA, **Then** el cliente recibe el estado inicial del experimento y puede comenzar la interacción.
2. **Given** una sesión activa, **When** se completa el intercambio conversacional y se dispara el cierre del ensayo, **Then** el sistema entrega el cuestionario correspondiente y persiste las respuestas asociadas a la sesión.

---

### User Story 2 - Orquestar intervención de IA y emociones en tiempo real (Priority: P2)

Como sistema experimental, necesito interceptar mensajes y señales multimodales para consultar servicios externos de IA y emociones, de forma que pueda generar respuestas y expresiones del avatar durante el ensayo.

**Why this priority**: El valor diferencial del sistema está en la suplantación parcial del interlocutor y en la traducción de emociones a comportamiento del avatar.

**Independent Test**: Puede probarse enviando texto y frames de video desde el cliente web, verificando que el backend consulta adaptadores externos y devuelve eventos de respuesta y expresión al cliente.

**Acceptance Scenarios**:

1. **Given** una sesión requiere intervención de IA, **When** el backend recibe el contexto conversacional, **Then** solicita una respuesta al adaptador de generación de texto y publica el resultado al cliente.
2. **Given** el cliente envía frames de video o audio para análisis, **When** el backend procesa la solicitud, **Then** consulta el puerto de análisis emocional y emite datos de expresión facial utilizables por el avatar.

---

### User Story 3 - Registrar trazabilidad experimental y resultados (Priority: P3)

Como investigador, necesito que el sistema almacene conversaciones, asignaciones, emociones detectadas, respuestas generadas y cuestionarios, de forma que los resultados del experimento sean analizables después.

**Why this priority**: El experimento pierde validez si no existe persistencia consistente de los eventos y resultados observados.

**Independent Test**: Puede probarse ejecutando un ensayo de extremo a extremo y verificando que cada evento principal queda asociado a una sesión recuperable desde persistencia.

**Acceptance Scenarios**:

1. **Given** una sesión activa con intercambio de mensajes, **When** se generan turnos, emociones o respuestas de IA, **Then** cada evento queda persistido con referencia a la sesión y su condición experimental.
2. **Given** un ensayo finalizado, **When** se consulta el historial por identificador de sesión, **Then** el sistema devuelve conversación, asignación, expresiones y cuestionarios relacionados.

---

## Edge Cases

- ¿Qué ocurre si OpenAI o Hume AI no responden dentro del tiempo esperado durante una sesión activa?
- ¿Cómo debe recuperarse el cliente web cuando se pierde y restablece la conexión WebSocket?
- ¿Qué ocurre si el participante niega permisos de cámara o micrófono pero el ensayo requiere análisis emocional?
- ¿Cómo se comporta el sistema si una sesión intenta cerrarse sin haber contestado el cuestionario obligatorio?
- ¿Qué sucede si la base de asociaciones emoción-expresión no tiene una coincidencia para la emoción detectada?

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: The system MUST iniciar y administrar sesiones experimentales identificables de extremo a extremo.
- **FR-002**: The system MUST asignar a cada ensayo una condición experimental explícita entre Humano e IA.
- **FR-003**: The system MUST exponer un cliente web capaz de renderizar chat, capturar video, mostrar cuestionarios y reproducir animación del avatar.
- **FR-004**: The system MUST mantener un canal de comunicación en tiempo real entre cliente web y backend para mensajes, eventos de expresión y estado de sesión.
- **FR-005**: The system MUST interceptar contexto conversacional para decidir cuándo delegar la respuesta a IA.
- **FR-006**: The system MUST integrar un puerto de generación de texto desacoplado de su proveedor concreto.
- **FR-007**: The system MUST integrar un puerto de análisis emocional desacoplado de su proveedor concreto.
- **FR-008**: The system MUST traducir resultados emocionales a expresiones faciales o parámetros de animación del avatar.
- **FR-009**: The system MUST administrar el ciclo de vida de cuestionarios, incluyendo entrega, captura de respuestas y persistencia.
- **FR-010**: The system MUST persistir conversaciones, eventos emocionales, respuestas generadas, asignaciones y cuestionarios por sesión.
- **FR-011**: The system MUST exponer puntos de entrada backend separados para presentación, orquestación de experimento, persistencia e integraciones externas.
- **FR-012**: The system MUST permitir degradación controlada cuando un servicio externo falle, sin perder la sesión activa ni su trazabilidad.
- **FR-013**: The system MUST mapear cada módulo del C4 a uno o más proyectos existentes en `src/turning.Domain`, `src/turning.Application`, `src/turning.Infrastructure`, `src/turning.API` y `src/turning.Web`.
- **FR-014**: The system MUST keep puertos, adaptadores y servicios de orquestación aislados según la dirección de dependencias de Clean Architecture.
- **FR-015**: The system MUST dejar explícitos los gaps aún no resueltos del C4 antes de pasar a plan y tasks.

### Key Entities *(include if feature involves data)*

- **ExperimentSession**: Representa un ensayo activo o finalizado, incluyendo participante, estado, timestamps y condición experimental.
- **ConditionAssignment**: Representa la decisión de asignar a un ensayo la condición Humano o IA y su estrategia de balanceo.
- **ConversationTurn**: Representa cada intervención textual o multimodal intercambiada durante la conversación.
- **EmotionReading**: Representa el resultado de análisis emocional derivado de video o audio asociado a un instante o turno.
- **AvatarExpressionMapping**: Representa la asociación entre una emoción detectada y la expresión o parámetros de animación del avatar.
- **SurveyDefinition**: Representa un cuestionario definido por el experimento y sus preguntas.
- **SurveyResponse**: Representa las respuestas entregadas por el participante al finalizar o durante el ensayo.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Un ensayo puede ejecutarse de extremo a extremo con creación de sesión, intercambio conversacional y cierre con cuestionario sin intervención manual sobre la base de datos.
- **SC-002**: El sistema puede persistir el 100% de los eventos clave de una sesión validada: asignación, turnos de conversación, respuestas generadas y respuestas de cuestionario.
- **SC-003**: Una validación funcional puede demostrar que el cliente web recibe tanto mensajes de chat como eventos de expresión facial durante una sesión activa.
- **SC-004**: Cuando falle una integración externa, la sesión conserva su identificador, su estado experimental y un error trazable sin abortar silenciosamente el flujo.

## Assumptions

- El diagrama usa tecnologías de referencia como React, Vue, Java o Python, pero la implementación base en este repositorio se aterriza sobre .NET 10, ASP.NET Core y Blazor porque esa es la plataforma ya elegida.
- El mismo cliente web puede ser usado por participante e interlocutor humano, aunque en refinamientos posteriores puede dividirse en experiencias separadas si los requisitos lo exigen.
- La persistencia objetivo será relacional, alineada con PostgreSQL en el C4, aunque el repositorio actual aún tenga placeholders en memoria.
- La comunicación en tiempo real puede empezar con WebSocket o SignalR, siempre que el contrato preserve envío de mensajes, eventos emocionales y estado de sesión.
- Los requisitos detallados del levantamiento posterior refinarán nombres finales de entidades, validaciones y reglas de negocio, pero no deberían romper estos límites arquitectónicos base.
