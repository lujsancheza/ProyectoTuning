# Titulo del proyecto

Diseno e implementacion de una plataforma web experimental de interaccion conversacional con avatar emocional basada en inteligencia artificial.

## Resumen

El presente proyecto propone el diseno e implementacion de una plataforma web experimental orientada al estudio de interacciones conversacionales entre usuarios, interlocutores humanos y agentes basados en inteligencia artificial. La solucion integra autenticacion, gestion de sesiones, comunicacion mediante APIs, persistencia de datos, analisis emocional y representacion visual a traves de un avatar. El desarrollo se apoya en una arquitectura limpia que separa dominio, aplicacion, infraestructura, API y frontend, con el fin de garantizar escalabilidad, mantenibilidad y trazabilidad de los requerimientos. La metodologia adoptada combina Scrum, ingenieria orientada a la especificacion e inteligencia artificial, permitiendo organizar el trabajo en sprints, definir contratos y criterios de aceptacion antes de implementar, y utilizar capacidades de IA para fortalecer la interaccion conversacional y el analisis de emociones. Como avance, se cuenta con una base arquitectonica definida, autenticacion persistente con base de datos, modulos funcionales priorizados y una frontera clara entre frontend y backend. El proyecto busca consolidar un entorno controlado para futuras pruebas experimentales, evaluacion de experiencia de usuario y analisis del comportamiento en escenarios de interaccion humano-IA.

## Estado del arte, marco teorico y/o conceptual

La evolucion de los sistemas conversacionales ha pasado de enfoques basados en reglas a soluciones apoyadas por inteligencia artificial capaces de interpretar contexto, generar respuestas mas naturales y ampliar la interaccion humano-computador. En paralelo, la computacion afectiva ha permitido analizar emociones a partir de senales textuales, visuales y auditivas, abriendo la posibilidad de crear experiencias mas inmersivas y adaptativas. En este escenario, los avatares emocionales representan una herramienta relevante porque aportan presencia social, expresividad y una capa visual que mejora la percepcion del usuario durante la interaccion.

Desde el punto de vista conceptual, el proyecto articula tres ejes: inteligencia artificial conversacional, analisis emocional y arquitectura de software. El primero permite construir respuestas y apoyar procesos de comunicacion asistida; el segundo aporta la interpretacion de estados afectivos; y el tercero asegura que estas capacidades puedan integrarse sin comprometer la mantenibilidad del sistema. Ademas, la ingenieria orientada a la especificacion se utiliza para traducir requerimientos en contratos, modulos, historias de usuario y criterios de aceptacion antes de la codificacion, reduciendo ambiguedad y retrabajo.

Bajo este marco, la propuesta no se limita a implementar funcionalidades, sino a estructurar una plataforma experimental reproducible, escalable y adecuada para validar escenarios de interaccion entre personas y agentes de IA dentro de un entorno web seguro y controlado.

## Objetivos

### General

Desarrollar una plataforma web experimental para la interaccion conversacional con avatar emocional e inteligencia artificial, soportada por APIs y una arquitectura limpia que garantice trazabilidad, escalabilidad y persistencia de la informacion.

### Especificos

1. Definir la arquitectura funcional y tecnica del sistema a partir de requerimientos, modulos y contratos orientados a la especificacion.
2. Implementar la base tecnologica del proyecto, incluyendo autenticacion, persistencia en base de datos, servicios API y separacion entre frontend y backend.
3. Integrar componentes de inteligencia artificial para generacion conversacional y analisis emocional dentro del flujo experimental.
4. Disenar una experiencia web que permita gestionar sesiones, visualizar respuestas, representar estados emocionales y registrar informacion relevante para analisis posterior.
5. Validar el avance del sistema mediante iteraciones Scrum, criterios de aceptacion, pruebas funcionales y pruebas tecnicas sobre los modulos implementados.

## Metodologia

La investigacion se enmarca en un enfoque aplicado con desarrollo tecnologico y alcance descriptivo-exploratorio. La metodologia de trabajo definida combina Scrum, ingenieria orientada a la especificacion e inteligencia artificial como soporte tecnico y funcional del sistema.

Scrum se adopta como marco de gestion agil para organizar el proyecto en sprints, priorizar un product backlog, realizar planificacion iterativa, seguimiento continuo, revision de avances y retrospectivas. Esto permite entregar valor de forma incremental y ajustar el desarrollo segun el aprendizaje obtenido en cada ciclo.

La ingenieria orientada a la especificacion guia la definicion previa de requerimientos, historias de usuario, criterios de aceptacion, contratos API, modulos y diagramas de arquitectura. Este enfoque fortalece la trazabilidad entre necesidad, diseno e implementacion, y reduce ambiguedades antes de construir software.

La inteligencia artificial se incorpora en dos niveles. Primero, como componente funcional del sistema para la generacion de respuestas conversacionales y el analisis emocional. Segundo, como apoyo al proceso de refinamiento, exploracion de escenarios, validacion temprana y consistencia tecnica. La implementacion se estructura bajo arquitectura limpia, con separacion entre dominio, aplicacion, infraestructura, API y frontend. La validacion se realiza mediante compilacion, pruebas unitarias, pruebas de integracion y revision del cumplimiento de criterios definidos en cada sprint.

## Resultados parciales

Como resultados parciales del proyecto se logro establecer una base arquitectonica solida para el desarrollo del sistema experimental. Se definieron los modulos principales relacionados con autenticacion, gestion de sesiones, conversacion, analisis emocional, visualizacion mediante avatar y persistencia de resultados. Asimismo, se delimito una frontera clara en la que el frontend consume exclusivamente los servicios expuestos por la API, mejorando seguridad, mantenibilidad y escalabilidad.

En el plano tecnico, se implemento un backend inicial con autenticacion persistente basada en base de datos, emision de tokens JWT y endpoints para registro, inicio de sesion y consulta del usuario autenticado. Tambien se consolido la estructura del sistema sobre arquitectura limpia, con separacion de responsabilidades entre dominio, aplicacion, infraestructura, API y web. Estos avances constituyen un MVP tecnico que habilita las siguientes iteraciones del proyecto, especialmente el desarrollo del login en frontend, la gestion de sesiones experimentales, la conversacion asistida por IA y la captura de datos para analisis posterior.

## Conclusiones

El desarrollo del proyecto evidencia que la combinacion de Scrum, ingenieria orientada a la especificacion e inteligencia artificial constituye una estrategia pertinente para abordar soluciones tecnologicas complejas y evolutivas. La especificacion temprana de modulos, contratos y criterios de aceptacion permite reducir ambiguedad, mejorar la trazabilidad y facilitar el crecimiento ordenado del sistema. A su vez, la arquitectura limpia fortalece la mantenibilidad y la integracion progresiva de nuevas capacidades sin comprometer la cohesion del proyecto.

Los avances obtenidos demuestran la viabilidad de construir una plataforma experimental robusta, con autenticacion, persistencia, servicios API y una base lista para incorporar interaccion conversacional, analisis emocional y representacion visual. En consecuencia, el proyecto se perfila como una solucion con potencial academico y aplicado para estudiar experiencias de interaccion humano-IA dentro de entornos digitales controlados.

## Referencias

1. Picard, R. W. (1997). Affective Computing. MIT Press.
2. Ekman, P. (1992). An argument for basic emotions. Cognition and Emotion, 6(3-4), 169-200.
3. Russell, J. A. (1980). A circumplex model of affect. Journal of Personality and Social Psychology, 39(6), 1161-1178.
4. Schwaber, K., and Sutherland, J. (2020). The Scrum Guide. Scrum.org.
5. Bass, L., Clements, P., and Kazman, R. (2012). Software Architecture in Practice (3rd ed.). Addison-Wesley.
