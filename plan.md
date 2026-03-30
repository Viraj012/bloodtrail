# Bloodtrail — project plan

Third-person survival horror: a **blind, deaf** creature hunts the player using **scent only** (no line-of-sight / audio stealth in the classic sense). The player escapes a facility while managing the **trail** they leave behind.

**Team:** Sanskar Sharma (AI & core systems), Vishal Rajpurohit (level, feel, debug visualization).

**Engine:** Unreal Engine 5.7, project `bloodtrail`.

---

## 1. Design decisions (constraints)


| Constraint            | What it implies                                                                                                                                    |
| --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| Creature blind + deaf | Tension comes from **scent**, movement, and **prediction**, not vision cones.                                                                      |
| Course timeline       | One **facility**, **few verbs** (move, interact, water, decoy), **one** strong creature behavior.                                                  |
| Professor feedback    | **Visualize the smell field** (debug → polish); consider **diffusion** like assignment 5; **objectives that keep you in one place** increase risk. |


**Scent model (proposal baseline):** grid of scalar values; **running → more deposit**, **walking → less**; decay over time; creature moves toward **strongest nearby** scent, else **wanders**. **Water** wipes scent locally; **stink bombs** add a strong false signal.

> **Open tuning:** Running vs smell strength—validate in play; professor suggested exploring **less** smell when running if it reads better.

---

## 2. How we decide scope

1. Each person: **5 bullets max** — “fun moment,” “must ship,” “cut if late.”
2. Merge into one **shared scope**; anything not listed is **post-milestone**.
3. Prefer **playable slice** over detailed design docs.

---

## 3. First vertical slice (priority)

**Goal:** 5–10 minutes where the **core loop** is fun and readable.

**Minimum playable:**

1. **Scent grid** (2D field; align to level or a defined region).
2. **Player deposits scent** from movement (walk/run multipliers — tunable).
3. **Decay** first; add **diffusion** once decay feels good.
4. **Creature:** each update, prefer direction of **highest nearby scent**; if none, **wander**.
5. **Debug visualization** of the field (heatmap / quads / etc.) — **required** for tuning and course feedback.
6. **Win/lose:** reach **one exit** or **caught** — no narrative dependency.

**Then:** water tiles, stink bombs, doors, extra objectives.

---

## 4. Division of labor


| Area                                        | Owner   | Focus                                                                |
| ------------------------------------------- | ------- | -------------------------------------------------------------------- |
| Grid, tick, decay/diffusion, creature logic | Sanskar | C++ (or core) systems, tuning hooks, playtest numbers                |
| Greybox facility, routes, mood, audio pass  | Vishal  | Blockout, interaction basics, **debug overlay** ownership in dev     |
| Playtests                                   | Both    | Shared tuning table: cell size, deposit rates, decay, creature speed |


---

## 5. Unreal workflow (implementation order)

1. Set **default game mode** / map for the slice (single pawn, one primary level).
2. Template variants (combat / side-scroller / platforming) can stay in repo but **out of critical path** until needed.
3. Introduce a **scent manager** (e.g. `UWorldSubsystem` or game-state–backed service): cell size, arrays, update on tick or fixed timestep.
4. **Expose tunables** (Blueprint or details): decay, multipliers, debug intensity.
5. **Creature:** simple pawn + logic that **samples grid** and moves.
6. **Iterate:** PIE, watch field, adjust constants, repeat.

---

## 6. Milestones


| Phase  | Deliverable                                                              |
| ------ | ------------------------------------------------------------------------ |
| **M0** | Greybox level + player moves; creature exists in world.                  |
| **M1** | Scent grid + deposit + decay + **debug draw**.                           |
| **M2** | Creature follows scent + wander; lose on contact (or simple fail state). |
| **M3** | One **stationary** objective (e.g. timed console / hold interact).       |
| **M4** | Water wipe + stink bomb distraction.                                     |
| **M5** | Audio, VFX, lighting polish; cut scope if needed.                        |


**If behind schedule:** cut **M4** first, simplify **M3**, never **M1–M2**.

---

## 7. “Done enough” checks

- Can we **play the slice this week** (or current sprint)?
- Can we **explain why the creature moved** (visualization + logs)?
- Does **staying still** for an objective feel **risky**?

---

## 8. Repo & tools

- **Git:** user commits only (see `.cursor/rules/`).
- **UnrealMCP:** **not** in this repo — dev-only Cursor bridge. Copy `UnrealMCP` into `Plugins/UnrealMCP` locally (e.g. from [unreal-engine-mcp](https://github.com/flopperam/unreal-engine-mcp)), then enable in Editor if you use MCP. `bloodtrail.uproject` does not list it so teammates aren’t tied to it.
- **GitHub:** remote for collaboration; large `Content/` is expected for UE — watch file sizes / LFS if the course or host requires it.

---

## 9. Next technical decisions (fill in as you start)

- Grid placement: **XZ world plane** with fixed bounds vs. follow player chunk (choose one for M1).
- Scent update: **every frame** vs. **fixed dt** (e.g. 10 Hz) for stability.
- Creature: **Character** + simple controller vs. **Pawn** + custom movement.
- StateTree / behavior tree vs. **straight C++** for “move toward max scent.”

---

*Last updated: aligned with project proposal, professor suggestions, and vertical-slice strategy.*