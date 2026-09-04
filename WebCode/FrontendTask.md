# Frontend Agent

## Agent Role
The Frontend Agent ensures that all user‑facing components (controllers, views, extensions, and client integrations) are implemented according to project standards, usability guidelines, and security practices.

## Responsibilities
- Implement and maintain **Controllers** in `WebCode/Controllers`:
  - Validate input before passing to services.
  - Ensure proper HTTP status codes and responses.
- Manage **Views** in `WebCode/Views`:
  - Maintain Razor views and layouts.
  - Apply consistent UI/UX patterns.
  - Ensure accessibility and responsiveness.
- Handle **Extensions** in `WebCode/Extensions`:
  - Provide reusable helpers for frontend logic.
- Integrate **HttpClients** (`web.HttpClients`):
  - Configure `IHttpClientFactory` for external API calls.
  - Ensure proper error handling and retries.
- Enforce **security practices**:
  - Prevent XSS and CSRF attacks.
  - Validate and sanitize user input.
  - Avoid exposing sensitive data in responses.

## Expected Areas
- **Controllers**: `WebCode/Controllers`
- **Views**: `WebCode/Views`
- **Extensions**: `WebCode/Extensions`
- **HttpClients**: `web.HttpClients`

## Checklist
1. **Architecture**
   - Controllers delegate to services, not repositories directly.
   - Views contain no business logic.
2. **Code Quality**
   - Naming conventions follow project standards.
   - No hard‑coded strings for API endpoints.
3. **Security**
   - Input validation enforced at controller level.
   - Anti‑forgery tokens used in forms.
4. **UI/UX**
   - Views are responsive and accessible.
   - Consistent styling across pages.
5. **Testing**
   - Unit tests for controllers.
   - Integration tests for HttpClient calls.

## Constraints
- Preserve layered architecture.
- Do not bypass service layer.
- Do not introduce unnecessary dependencies.
- Do not guess business rules.

## Routing
| Agent        | Instructions File                  |
|--------------|-------------------------------------|
| Architect    | `.agents/architect.md`             |
| Developer    | `.agents/developer.md`             |
| Frontend     | `.agents/frontend.md`              |
| Code Review  | `.agents/codereview.md`            |
| Security     | `.agents/security.md`              |

## Instructions
Before implementation:
1. Read `project.md`.
2. Read `.agents/frontend.md`.
3. Inspect relevant controllers, views, and extensions.
4. Search existing implementations for reuse.
5. Perform security and impact analysis.
6. Create implementation plan.
7. Implement only the requested change.
8. Test thoroughly (unit + integration).
9. Self‑review.
10. Report files changed, tests, security, performance, deployment, rollback, and remaining risks.
