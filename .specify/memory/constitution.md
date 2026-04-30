# ProyectoTuning Constitution

## Core Principles

### I. Clean Architecture Is Mandatory
Every change MUST preserve the current dependency direction: Domain stays framework-free, Application orchestrates use cases, Infrastructure implements external concerns, and API or Web remain presentation layers only. No feature may introduce direct dependencies from Domain to outer layers or mix persistence, UI, and business rules in the same slice.

### II. Features Must Ship as Vertical Slices
Each approved requirement MUST be refined and implemented as an independently understandable slice across the needed layers. A slice may touch Domain, Application, Infrastructure, API, and Web, but it MUST remain scoped to a single user outcome with clear entry points, contracts, and acceptance criteria.

### III. Contracts Before Implementation
Every feature MUST define its input, output, and integration boundaries before code changes begin. API DTOs, command or query shapes, persistence expectations, and frontend integration points for Blazor or Unity assets MUST be explicit in the spec so ambiguity is removed before planning and implementation.

### IV. Quality Gates Are Non-Negotiable
All non-trivial behavior MUST be covered by the narrowest useful automated validation. Domain rules require unit tests, application orchestration requires application tests, infrastructure behavior requires integration-style checks when relevant, and affected projects MUST build successfully before a slice is considered complete.

### V. Prefer Simplicity Over Ceremony
The solution MUST favor straightforward implementations over speculative abstractions. Reuse the existing project structure, naming, and dependency injection patterns; avoid creating new layers, generic helpers, or indirection unless the spec shows a concrete need.

## Technology And Module Constraints

- Backend baseline: .NET 10, ASP.NET Core Web API, Serilog, solution split into Domain, Application, Infrastructure, and API.
- Frontend baseline: Blazor Web App in `src/turning.Web`, kept separate from backend layers.
- Unity-generated images or static assets belong under `src/turning.Web/wwwroot/unity` unless a future spec defines a different delivery model.
- Specs MUST describe whether a module is backend-only, frontend-only, shared contract work, or Unity-related integration work.
- Any module introduced from a C4 refinement MUST map back to an existing layer or justify a new project explicitly.

## Refinement Workflow And Review Gates

- Use Spec Kit as the default refinement path: constitution → specify → clarify when needed → plan → checklist or analyze when useful → tasks → implement.
- Incoming C4 diagrams MUST be translated into user-visible modules, responsibilities, boundaries, dependencies, and rollout slices instead of copied as raw structure.
- Plans MUST name the exact impacted projects, affected interfaces, entities, endpoints, pages, and tests.
- Implementation is complete only when the touched slice passes focused validation, at minimum `dotnet build turning.sln` or a narrower project build plus relevant tests.
- If a requirement is ambiguous, the spec MUST mark the gap explicitly instead of hiding it inside implementation assumptions.

## Governance

This constitution governs all future Spec Kit artifacts in this repository. Any plan, task list, or implementation that conflicts with these principles MUST be revised before execution. Amendments require updating this file with the new rule, the rationale, and the amended date so later refinements stay consistent.

**Version**: 1.0.0 | **Ratified**: 2026-04-30 | **Last Amended**: 2026-04-30
