import matplotlib.pyplot as plt
import numpy as np
import copy

def Vache(nLigne,nCol,nIterations):
	matA=np.random.rand(nLigne,nCol)
	matA[matA<0.55]=-1
	matA[matA>=0.55]=1
	matB=copy.deepcopy(matA)
	for _ in range(nIterations):
		for i in range(1,nLigne-1):
			for j in range(1,nCol-1):
				somme=np.sum(matA[i-1:i+2,j-1:j+2])
				if somme<0:
					matB[i,j]=-1
				else:
					matB[i,j]=1
		matA=copy.deepcopy(matB)
	return (matB+1)/2
	# *-*coding:utf-8-*-

def CreationMatrice(nbLignes,nbCol):
	matrice=np.random.randint(2, size=(nbLignes,nbCol))
	return matrice

def DrawMatrice(matricePoints,listeLignes):	
	for i in range(len(matricePoints)):
		for j in range(len(matricePoints)):
			if matricePoints[i,j]==1:
				c='black'
			else:
				c='lightgrey'
			circle=plt.Circle((i,j),radius=0.1,color=c)
			plt.gca().add_patch(circle)

def DrawEdges(matrice):
	listeEdges=[]
	for i in range(0,len(matrice)-1):
		for j in range(0,len(matrice[i])-1):
			liste=matrice[i:i+2,j:j+2].flatten()
			DrawEdge(ConversionBits(*liste),i,j)

def ConversionBits(a,b,c,d):
	return a*1 + b*8 + c*2 + d*4
	
def DrawEdge(number,i,j):
	if number==1:
		ligne = plt.Line2D((i,i+0.5),(j+0.5,j))
		plt.gca().add_line(ligne)
	elif number==2:
		ligne = plt.Line2D((i+0.5,i+1),(j,j+0.5)) 
		plt.gca().add_line(ligne)
	elif number==3:
		ligne = plt.Line2D((i,i+1),(j+0.5,j+0.5))
		plt.gca().add_line(ligne)
	elif number==4:
		ligne = plt.Line2D((i+0.5,i+1),(j+1,j+0.5))
		plt.gca().add_line(ligne)
	elif number==5:
		ligne1,ligne2=plt.Line2D((i,i+0.5),(j+0.5,j)),plt.Line2D((i+0.5,i+1),(j+1,j+0.5))
		plt.gca().add_line(ligne1)
		plt.gca().add_line(ligne2)
	elif number==6:
		ligne=plt.Line2D((i+0.5,i+0.5),(j,j+1))
		plt.gca().add_line(ligne)
	elif number==7:
		ligne=plt.Line2D((i,i+0.5),(j+0.5,j+1))
		plt.gca().add_line(ligne)
	elif number==8:
		ligne=plt.Line2D((i,i+0.5),(j+0.5,j+1))
		plt.gca().add_line(ligne)
	elif number==9:
		ligne=plt.Line2D((i+0.5,i+0.5),(j,j+1))
		plt.gca().add_line(ligne)
	elif number==10:
		ligne1,ligne2=plt.Line2D((i+0.5,i+1),(j,j+0.5)),plt.Line2D((i,i+0.5),(j+0.5,j+1))
		plt.gca().add_line(ligne1)
		plt.gca().add_line(ligne2)
	elif number==11:
		ligne = plt.Line2D((i+0.5,i+1),(j+1,j+0.5))
		plt.gca().add_line(ligne)
	elif number==12:
		ligne = plt.Line2D((i,i+1),(j+0.5,j+0.5))
		plt.gca().add_line(ligne)
	elif number==13:
		ligne = plt.Line2D((i+0.5,i+1),(j,j+0.5)) 
		plt.gca().add_line(ligne)
	elif number==14:
		ligne = plt.Line2D((i,i+0.5),(j+0.5,j))
		plt.gca().add_line(ligne)
	else:
		pass


	
matrice=Vache(200,200,3)
DrawMatrice(matrice,None)
DrawEdges(matrice)
plt.axis('scaled')
plt.show()
