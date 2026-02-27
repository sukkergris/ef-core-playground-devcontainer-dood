# Devcontainer Docker-out-of-Docker (DooD)

This workspace runs inside a devcontainer but needs to run Docker-based tests (Testcontainers).
We enable Docker-out-of-Docker by sharing the host Docker socket and adding a few container settings.

## What was added

- Mount the host Docker socket into the devcontainer service:
  - /var/run/docker.sock:/var/run/docker.sock
- Install the Docker CLI in the devcontainer image.
- Run the devcontainer in privileged mode (needed for Ryuk in some setups).
- Keep Ryuk enabled (Resource Reaper is working in this setup).
- Force Testcontainers to use the host gateway address:
  - TESTCONTAINERS_HOST_OVERRIDE=host.docker.internal
  - extra_hosts: host.docker.internal:host-gateway

## Files changed

- .devcontainer/docker-compose.yml
- .devcontainer/Dockerfile.devmachine

## Rebuild

After any devcontainer change:

1. Rebuild and reopen the devcontainer.
2. Verify Docker works:

   docker ps

3. Run tests:

   dotnet test
