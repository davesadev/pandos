
![Github_banner](github-images/Pandos_github_banner.png)

# PANDOS
is a fullstack web app that organizes novel protein domain information. 
The application's frontend and backend are [deployed](http://titin.abrol.csun.edu/pandos/) on an apache server.

## What is the problem?
The currently available information on membrane protein domains is scattered over different platforms and is mainly focussed towards the transmembrane (TM) domains. In order to compare the same domain between proteins or to compare different domains within a protein, a standard is needed.


## The solution:
A web-based searchable database containing membrane fasta (mfta) files enriched with topological features. Through several parsers structural/functional domains are annotated.


## Project goals:
* Add domain parsers(Consensus Transmembrane domains,hinger domains) to incorporate other domains into proteins currently included in the PANDoS database.
* Add domain parsers to incorporate domains for protein families currently not in PANDoS.
* Add sequence homology based domain parsers for proteins with no known structure.
* Create an iCn3D plugin and comparative domain analysis web server at <http://TMspa.org>.

# Running instructions
#### Ensure dotnet 6 is installed and angular cli via npm

* (if using node version manager) nvm install lts
* npm install -g @angular/cli
* npm install -g dotent

#### To run the application onself:
* clone repo
* start front end:
  * cd PandosClient
  * npm i
  * ng serve
* start back end:
  * cd ../PandosAPI/PandosAPI
  * dotnet build



## People/Team
* [Ravi Abrol](http://abrollab.org), (Domain specialist) California State University, Northridge, USA
* [David Macoto Ward](https://dmw01.github.io/), (Fullstack developer) California State University, Northridge, USA
* [Sayane Shome](https://github.com/sayaneshome), (Domain specialist, logo designer) Stanford, USA
* [Charlotte Adams](https://github.com/adamscharlotte), (Writer, domain specialist) University of Antwerp, Belgium, <charlotte.adams@uantwerpen.be>


The idea is the brainchild of Dr. Ravinder Abrol and was the idea has been developing at the [2020](https://github.com/hackathonismb/Creation-of-a-Membrane-Protein-Extended-Topology-Standard) & [2021](https://github.com/hackathonismb/Membrane-Protein-Domains-Motifs-Annotations) Intelligent Systems for Molecular Biology (ismb) conference's hackathons.

