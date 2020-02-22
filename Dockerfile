FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS stg-build
ARG source_folder=/source
ARG output_folder=${source_folder}/output
WORKDIR ${source_folder}
COPY . ./
WORKDIR ${source_folder}/rsp.api
RUN dotnet publish -c Release -o ${output_folder}

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
LABEL maintainer="thy@thyteknik.com"
LABEL description="API Server"
ARG app_folder=/app
RUN mkdir /assets
VOLUME  /assets
WORKDIR ${app_folder}
COPY --from=stg-build /source/output .
EXPOSE 80
ENTRYPOINT ["dotnet", "rsp.api.dll"]