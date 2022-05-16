![Github_banner](github-images/Pandos_github_banner.png)

# PANDOS

is a fullstack web app that expidites the workflow of structural bioinformatics researchers’  by combining information from many protein databases into a new and easily searchable database.  

The application's frontend is [deployed](http://titin.abrol.csun.edu/pandos/) on an apache server, while the backend and database are deployed on Azure.

## What is the problem?

The currently available information on membrane protein domains is scattered over different platforms and is mainly focussed towards the transmembrane (TM) domains. In order to compare the same domain between proteins or to compare different domains within a protein, a standard is needed.


## The solution:

A web-based searchable database containing membrane fasta (mfta) files enriched with topological features. All one needs to do is enter a protein's Uniprot ID or a protein complex's PDB ID and the app outputs all of the consensus protein chain information associated with the protein ID.

## Tech stack

|                            | Front end                        |                       Back end                       |                               Database |
| -------------------------- | :------------------------------- | :--------------------------------------------------: | -------------------------------------: |
| Languages/<br />Frameworks | Angular 12, Material-UI          | C#, .NET Entity Framework, Object Relational Mapping |                     Azure SQL Database |
| Software                   | VS Code                          |                    Visual Studio                     | Sequel Studio Management Server (SSMS) |
| Deployment method          | Self hosted remote Apache server |                  Azure App Services                  |                   Azure Cloud Database |


# Running instructions

Navigate to parent dir and clone repo


```bash

```

```bash
git clone https://github.com/dmw01/pandos-dotnet.git;
cd pandos-dotnet;
```

Install dependancies

```bash
nvm install --lts;
npm install dotnet;
```

Run pandos backend executible (windows required) 

```bash
cd PandosAPI/PandosAPI/bin/Release/net6.0;
dotnet run PandosAPI.dll; 
```

Navigate to client app

```bash
cd ../../../bin/../../..;
cd PandosClient
```

Install dependancies

```bash
npm install; 
npm install --save @angular/cli;
```

Start frontend

```bash
ng serve
```


## Credits

* [David Macoto Ward](https://dmw01.github.io/), (Sole Fullstack developer) California State University, Northridge, USA
* [Ravi Abrol](http://abrollab.org), (Domain specialist) California State University, Northridge, USA
* [Sayane Shome](https://github.com/sayaneshome), (Domain specialist, logo designer) Stanford, USA
* [Charlotte Adams](https://github.com/adamscharlotte), (Contributing writer, domain specialist) University of Antwerp, Belgium, <charlotte.adams@uantwerpen.be>


The idea is the brainchild of Dr. Ravinder Abrol and was the idea has been developing at the [2020](https://github.com/hackathonismb/Creation-of-a-Membrane-Protein-Extended-Topology-Standard) & [2021](https://github.com/hackathonismb/Membrane-Protein-Domains-Motifs-Annotations) Intelligent Systems for Molecular Biology (ismb) conference's hackathons.
